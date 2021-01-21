using OpenQA.Selenium;
using System;
using NLog;
using Yandex_practice.Common.WebElements;
using Yandex_practice.Tests.TestData;
using Yandex_practice.WrapperFactory;
using Yandex_practice.Common.Extensions;

namespace Yandex_practice.PageObjects
{
    public class DiskPage
    {        
        private UIElement _createButton = new UIElement(Common.Enums.FindBy.XPath, "//*[contains(text(), 'Создать')]/ancestor::button");

        private UIElement _newFolder = new UIElement(Common.Enums.FindBy.XPath, "//*[contains(text(), 'Папку')]/ancestor::button");

        private UIElement _newDocument = new UIElement(Common.Enums.FindBy.XPath, "//*[contains(text(), 'Текстовый документ')]/ancestor::button");

        private UIElement _inputFolderName = new UIElement(Common.Enums.FindBy.XPath, "//form[@class='rename-dialog__rename-form']/descendant::input");

        private UIElement _saveButton = new UIElement(Common.Enums.FindBy.XPath, "//*[contains(text(), 'Сохранить')]/ancestor::button");
                
        private UIElement _createdFolder = new UIElement(Common.Enums.FindBy.XPath, "//div[@class='listing-item__info']");
                
        private UIElement _createdDoc = new UIElement(Common.Enums.FindBy.XPath, "//span[contains(text(), 'test')]");
                
        private UIElement _selectedItemInfo = new UIElement(Common.Enums.FindBy.XPath, "//div[contains(@class,'listing-item_selected')]/descendant::span[@class='clamped-text']");

        private UIElement _searchInput = new UIElement(Common.Enums.FindBy.XPath, "//form[@class='client-search-input__form']/descendant::input");

        private UIElement _searchResult = new UIElement(Common.Enums.FindBy.XPath, "//div[@id='suggest-result-item-0']");

        private UIElement _closeButton = new UIElement(Common.Enums.FindBy.XPath, "(//div[@class='hover-tooltip__tooltip-anchor']/descendant::button)[last()]");

        private UIElement _docNameButton = new UIElement(Common.Enums.FindBy.XPath, "//button[@id='documentTitle']");

        private UIElement _docNameInput = new UIElement(Common.Enums.FindBy.XPath, "//input[@id='CommitNewDocumentTitle']");

        private UIElement _paragraph = new UIElement(Common.Enums.FindBy.XPath, "//div[@id='WACViewPanel_EditingElement']");

        private UIElement _moveButton = new UIElement(Common.Enums.FindBy.XPath, "(//span[contains(text(), 'Переместить')]/ancestor::button)[1]");

        private UIElement _finishMoveButton = new UIElement(Common.Enums.FindBy.XPath, "(//span[contains(text(), 'Переместить')]/ancestor::button)[last()]");

        private UIElement _editControl = new UIElement(Common.Enums.FindBy.XPath, "//span[contains(text(), 'Редактировать')]/ancestor::button");               

        private UIElement _removeControl = new UIElement(Common.Enums.FindBy.XPath, "//span[contains(text(), 'Удалить')]/ancestor::button");

        private UIElement _paragraphContent = new UIElement(Common.Enums.FindBy.XPath, "//span[contains(text(),'updated')]");

        private UIElement _secondFolder = new UIElement(Common.Enums.FindBy.XPath, "//div[contains(@title, 'secondfolder')]");

        private UIElement _savedStatus = new UIElement(Common.Enums.FindBy.XPath, "//span[contains(text(), 'Сохранено в Yandex')]");        
        
        private UIElement _notification = new UIElement(Common.Enums.FindBy.XPath, "//div[@class='notifications__text js-message']");

        private static Logger logger = LogManager.GetCurrentClassLogger();

        public void CreateNewFolder()
        {
            logger.Debug("Create new Folder");
            _createButton.Click();
            _newFolder.Click();
            _inputFolderName.Clear();
            Guid g = Guid.NewGuid();
            var gName = g.ToString();
            _inputFolderName.SendKeys(gName);
            _saveButton.Click();            
        }

        public bool CheckNewFolder()
        {
            logger.Debug("Get new Folder");
            return _createdFolder.Displayed;
        }

        public void CreateSecondFolder()
        {
            logger.Debug("Create second folder");
            _createButton.Click();
            _newFolder.Click();
            _inputFolderName.Clear();
            _inputFolderName.SendKeys(OtherConstants.secondfolder);
            _saveButton.Click();
            _createdFolder.ConfirmElementDisplayed();
        }
                
        public void NavigateNewFolder()
        {
            logger.Debug("Open new Folder");
            _selectedItemInfo.ConfirmTextNotNull();
            string folderName = _selectedItemInfo.GetAttribute("title");
            _closeButton.Click();
            _searchInput.SendKeys(folderName);
            _searchResult.Click();
        }

        public void NavigateSecondFolder()
        {
            logger.Debug("Open second Folder");
            _searchInput.Clear();
            _searchInput.SendKeys(OtherConstants.secondfolder);           
            _searchResult.Click();
        }

        public void CreateNewDoc(string docname)
        {
            logger.Debug("Create new doc");
            _createButton.Click();
            _newDocument.Click();
            WebDriverFactory.SwitchToNewWindow();
            WebDriverFactory.SwitchToIframe();
            _docNameButton.Click();
            _docNameInput.Clear();
            _docNameInput.SendKeys(docname + Keys.Enter);
            _paragraph.ConfirmElementDisplayed();
            _paragraph.Click();
            _paragraph.SendKeys(docname);
            _savedStatus.ConfirmElementDisplayed();
        }              

        public bool CheckProgressStatus()
        {
            logger.Debug("Check in progress status");
            return _notification.Displayed;
        }       

        public void MoveDoc()
        {
            logger.Debug("Move doc");
            _createdDoc.Click();
            _moveButton.Click();
            _secondFolder.Click();
            _finishMoveButton.Click();
            _notification.ConfirmElementDisplayed();
        }

        public bool IsDocExist(string docname)
        {
            logger.Debug("Check doc is exist");
            return WebDriverFactory.Driver.FindElements(By.XPath($"//span[contains(text(), '{docname}.docx')]")).Count > 0;
        }        

        public void RenameDoc(string newdocname)
        {
            logger.Debug("Rename doc");
            _createdDoc.Click();
            _editControl.Click();
            WebDriverFactory.SwitchToNewWindow();
            WebDriverFactory.SwitchToIframe();
            _docNameButton.Click();
            _docNameInput.Clear();
            _docNameInput.SendKeys(newdocname + Keys.Enter);
            _savedStatus.ConfirmElementDisplayed();
        }

        public void UpdateDoc(string updatedcontent)
        {
            logger.Debug("Update doc");
            _createdDoc.Click();
            _editControl.Click();
            WebDriverFactory.SwitchToNewWindow();
            WebDriverFactory.SwitchToIframe();
            _paragraph.Click();
            //_paragraph.Clear();
            _paragraph.SendKeys(Keys.Control + 'A' + Keys.Backspace);
            _paragraph.SendKeys(updatedcontent);
            _savedStatus.ConfirmElementDisplayed();
        }

        public string GetUpdatedDoc()
        {
            logger.Debug("Check doc is renamed");
            _createdDoc.Click();
            _editControl.Click();
            WebDriverFactory.SwitchToNewWindow();
            WebDriverFactory.SwitchToIframe();
            return _paragraphContent.Text;
        }

        public void RemoveDoc(string docname)
        {
            logger.Debug("Remove doc");
            _createdDoc.Click();
            _removeControl.Click();
            _notification.ConfirmElementDisplayed();

            try
            {
                while (IsDocExist(docname))
                {
                    WebDriverFactory.ReloadThePage();
                    _createdDoc.Click();
                    _removeControl.Click();
                    _notification.ConfirmElementDisplayed();
                }
            }
            catch (NoSuchElementException)
            {
                //nothing
            }            

        }
    }
}
