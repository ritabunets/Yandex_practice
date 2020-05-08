using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium.Community.PageObjects;
using System;
using Yandex_practice.WrapperFactory;
using Yandex_practice.TestConfig;

namespace Yandex_practice.PageObjects
{
    public class DiskPage
    {
        [FindsBy(how: How.XPath, @using: "//button[@class='control button2 button2_view_default button2_tone_default button2_size_n button2_theme_raised button2_width_max']")]
        private IWebElement _createButton;

        [FindsBy(how: How.XPath, @using: "//button[@class='create-resource-button create-resource-popup-with-anchor__create-item']")]
        private IWebElement _newFolder;

        [FindsBy(how: How.XPath, @using: "//button[@class='create-resource-button create-resource-popup-with-anchor__create-item'][2]")]
        private IWebElement _newDocument;

        [FindsBy(how: How.XPath, @using: "//form[@class='rename-dialog__rename-form']/span/input")]
        private IWebElement _inputFolderName;

        [FindsBy(how: How.XPath, @using: "//button[@class='control button2 button2_view_default button2_tone_default button2_size_n button2_theme_raised button2_action_yes confirmation-dialog__button confirmation-dialog__button_submit ']")]
        private IWebElement _saveButton;

        [FindsBy(how: How.XPath, @using: "//span[contains(text(), gName)]")]
        private IWebElement _createdFolder;

        [FindsBy(how: How.XPath,@using: "//div[(contains(@class, 'js-disabled'))]/div[@class='b-tree__sub ns-view-container-desc']")]
        private IWebElement _createdFolderItem;

        [FindsBy(how: How.XPath, @using: "//span[contains(text(), 'test')]")]
        private IWebElement _createdDoc;

        [FindsBy(how: How.XPath, @using: "//div[@class='listing-item listing-item_theme_tile listing-item_size_m listing-item_type_dir listing-item_selected js-prevent-deselect']")]
        private IWebElement _selectedItemInfo;

        [FindsBy(how: How.XPath, @using: "//form[@class='search-input__form']/span/input")]
        private IWebElement _searchInput;

        [FindsBy(how: How.XPath, @using: "//div[@class='search-result__item search-result__item_type_folders']")]
        private IWebElement _searchResult;

        [FindsBy(how: How.XPath, @using: "//button[@class='control button2 button2_view_classic button2_size_n button2_theme_clear-inverse resources-action-bar__close']")]
        private IWebElement _closeButton;

        [FindsBy(how: How.XPath, @using: "//button[@id='documentTitle']")]
        private IWebElement _docNameButton;

        [FindsBy(how: How.XPath, @using: "//input[@id='CommitNewDocumentTitle']")]
        private IWebElement _docNameInput;

        [FindsBy(how: How.XPath, @using: "//p[@class='Paragraph']")]
        private IWebElement _paragraph;

        [FindsBy(how: How.XPath, @using: "//button[@class='control button2 button2_view_classic button2_size_n button2_theme_clear-inverse groupable-buttons__visible-button groupable-buttons__visible-button_name_move ']")]
        private IWebElement _moveButton;

        [FindsBy(how: How.XPath, @using: "//button[@class='control button2 button2_view_default button2_tone_default button2_size_n button2_theme_raised button2_action_yes confirmation-dialog__button confirmation-dialog__button_submit ']")]
        private IWebElement _finishMoveButton;

        [FindsBy(how: How.XPath, @using: "//button[@class='control button2 button2_view_classic button2_size_n button2_theme_clear-inverse groupable-buttons__visible-button groupable-buttons__visible-button_name_edit ']")]
        private IWebElement _editControl;

        [FindsBy(how: How.XPath, @using: "//span[contains(text(), 'renamed')]")]
        private IWebElement _renamedDoc;

        [FindsBy(how: How.XPath, @using: "//button[@class='control button2 button2_view_classic button2_size_n button2_theme_clear-inverse groupable-buttons__visible-button groupable-buttons__visible-button_name_delete ']")]
        private IWebElement _removeControl;

        [FindsBy(how: How.XPath, @using: "//span[contains(text(),'updated')]")]
        private IWebElement _paragraphContent;

        [FindsBy(how: How.XPath, @using: "//div[contains(@title, 'secondfolder')]")]
        private IWebElement _secondFolder;

        public void CreateNewFolder()
        {
            _createButton.Click();
            _newFolder.Click();
            _inputFolderName.SendKeys(Keys.Control + 'A' + Keys.Backspace);
            Guid g = Guid.NewGuid();
            var gName = g.ToString();
            _inputFolderName.SendKeys(gName);
            _saveButton.Click();
        }

        public void CreateSecondFolder()
        {
            _createButton.Click();
            _newFolder.Click();
            _inputFolderName.SendKeys(Keys.Control + 'A' + Keys.Backspace);
            _inputFolderName.SendKeys(Constants.secondfolder);
            _saveButton.Click();
        }

        public bool GetNewFolder()
        {
            return _createdFolder.Displayed;
        }
        
        public string GetFolderName()
        {
            return _selectedItemInfo.Text;
        }

        public void NavigateNewFolder()
        {
            string folderName = Page.Disk.GetFolderName();
            _closeButton.Click();
            _searchInput.SendKeys(folderName);
            _searchInput.Click();

            try
            {

                while (!GetSearchResult())
                {
                    _searchInput.SendKeys(Keys.Backspace);
                    WebDriverWait wait = new WebDriverWait(WebDriverFactory.Driver, TimeSpan.FromSeconds(5));
                    wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@class='search-result__item search-result__item_type_folders']")));

                }
            }
            catch (NoSuchElementException)
            {
                //nothing
            }
            
            _searchResult.Click();
        }

        public void NavigateSecondFolder()
        {
            
            _searchInput.SendKeys(Constants.secondfolder);
            _searchInput.Click();

            try
            {

                while (!GetSearchResult())
                {
                    _searchInput.SendKeys(Keys.Backspace);
                    WebDriverWait wait = new WebDriverWait(WebDriverFactory.Driver, TimeSpan.FromSeconds(5));
                    wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@class='search-result__item search-result__item_type_folders']")));

                }
            }
            catch (NoSuchElementException)
            {
                //nothing
            }


            _searchResult.Click();

        }

        public bool GetSearchResult()
        {
            return WebDriverFactory.Driver.FindElements(By.XPath("//div[@class='search-result__item search-result__item_type_folders']")).Count > 0;
        }

        public void CreateNewDoc()
        {
            _createButton.Click();
            _newDocument.Click();
            WebDriverFactory.SwitchToNewWindow();
            WebDriverFactory.SwitchToIframe();
            _docNameButton.Click();
            _docNameInput.SendKeys(Keys.Control + 'A' + Keys.Backspace);
            _docNameInput.SendKeys("test" + Keys.Enter);
            _paragraph.Click();
            _paragraph.SendKeys("test");
            WebDriverWait wait = new WebDriverWait(WebDriverFactory.Driver, TimeSpan.FromMinutes(1));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[contains(text(), 'Сохранено в Yandex')]")));
        }                           
        
        public void MoveDoc()
        {
            _createdDoc.Click();
            _moveButton.Click();
            _secondFolder.Click();
            _finishMoveButton.Click();

            WebDriverWait wait = new WebDriverWait(WebDriverFactory.Driver, TimeSpan.FromMinutes(1));
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@class='notifications__item nb-island notifications__item_moved']")));

            try
            {

                while (IsDocExist())
                {
                    WebDriverFactory.ReloadThePage();
                    _createdDoc.Click();
                    _moveButton.Click();
                    _secondFolder.Click();                   
                    _finishMoveButton.Click();
                    wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@class='notifications__item nb-island notifications__item_moved']")));

                }
            }
            catch (NoSuchElementException)
            {
                //nothing
            }

        }

        public bool IsDocExist()
        {
            return WebDriverFactory.Driver.FindElements(By.XPath("//span[contains(text(), 'test')]")).Count > 0;
        }

        public bool GetNewDoc()
        {
            return _createdDoc.Displayed;
        }
                
        public bool GetRenamedDoc()
        {
            return _renamedDoc.Displayed;
        }

        public void RenameDoc()
        {
            _createdDoc.Click();
            _editControl.Click();
            WebDriverFactory.SwitchToNewWindow();
            WebDriverFactory.SwitchToIframe();
            _docNameButton.Click();
            _docNameInput.SendKeys(Keys.Control + 'A' + Keys.Backspace);
            _docNameInput.SendKeys("renamed" + Keys.Enter);
            WebDriverWait wait = new WebDriverWait(WebDriverFactory.Driver, TimeSpan.FromMinutes(1));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[contains(text(), 'Сохранено в Yandex')]")));
        }

        public void UpdateDoc()
        {
            _createdDoc.Click();
            _editControl.Click();
            WebDriverFactory.SwitchToNewWindow();
            WebDriverFactory.SwitchToIframe();
            _paragraph.Click();
            _paragraph.SendKeys(Keys.Control + 'A' + Keys.Backspace);
            _paragraph.SendKeys("updated");
            WebDriverWait wait = new WebDriverWait(WebDriverFactory.Driver, TimeSpan.FromMinutes(1));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[contains(text(), 'Сохранено в Yandex')]")));
        }

        public string GetUpdatedDoc()
        {
            _createdDoc.Click();
            _editControl.Click();
            WebDriverFactory.SwitchToNewWindow();
            WebDriverFactory.SwitchToIframe();
            return _paragraphContent.Text;
        }

        public void RemoveDoc()
        {
            _createdDoc.Click();
            _removeControl.Click();

            WebDriverWait wait = new WebDriverWait(WebDriverFactory.Driver, TimeSpan.FromMinutes(1));
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@class='notifications__text js-message']")));

            try
            {

                while (IsDocExist())
                {
                    WebDriverFactory.ReloadThePage();
                    _createdDoc.Click();
                    _removeControl.Click();
                    wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@class='notifications__text js-message']")));

                }
            }
            catch (NoSuchElementException)
            {
                //nothing
            }
        }
    }
}
