using Yandex_practice.WrapperFactory;
using Yandex_practice.Tests.TestConfig;
using NLog;
using Yandex_practice.Common.WebElements;
using OpenQA.Selenium;
using Yandex_practice.Common.Extensions;

namespace Yandex_practice.PageObjects
{    
    public class AuthenticationPage
    {                         
        private UIElement _loginInput = new UIElement(Common.Enums.FindBy.XPath,"//input[@id='passp-field-login']");

        private UIElement _passwordInput = new UIElement(Common.Enums.FindBy.XPath, "//input[@id='passp-field-passwd']");

        private UIElement _forgotLoginLink = new UIElement(Common.Enums.FindBy.XPath, "//a[contains(text(), 'логин')]");

        private UIElement _forgotPasswordLink = new UIElement(Common.Enums.FindBy.XPath, "//a[contains(text(), 'пароль')]");

        private UIElement _logInButton = new UIElement(Common.Enums.FindBy.XPath, "//button[@data-t='button:action']");

        private UIElement _qrCodeButton = new UIElement(Common.Enums.FindBy.XPath, "//button[@data-t='provider:primary:qr']");

        private UIElement _registrationButton = new UIElement(Common.Enums.FindBy.XPath, "//*[contains(text(), 'Зарегистрироваться')]/ancestor::a");
              
        private UIElement _iconGoogle = new UIElement(Common.Enums.FindBy.XPath, "//button[@data-t='provider:primary:gg']");
               
        private UIElement _iconMore = new UIElement(Common.Enums.FindBy.XPath, "//button[@data-t='provider:more']");
        
        private UIElement _personalInfoFirstName = new UIElement(Common.Enums.FindBy.XPath, "//div[@class='personal-info__first']");

        private UIElement _personalInfoLastName = new UIElement(Common.Enums.FindBy.XPath, "//div[@class='personal-info__last']");

        private UIElement _loginInputGoogle = new UIElement(Common.Enums.FindBy.XPath, "//input[@type='email']");

        private UIElement _loginNextButtonGoogle = new UIElement(Common.Enums.FindBy.XPath, "//div[@id='identifierNext']");

        private UIElement _passwordNextButtonGoogle = new UIElement(Common.Enums.FindBy.XPath, "//div[@id='passwordNext']");

        private UIElement _passwordInputGoogle = new UIElement(Common.Enums.FindBy.XPath, "//input[@type='password']");

        private UIElement _errorText = new UIElement(Common.Enums.FindBy.XPath, "//div[@class='Textinput-Hint Textinput-Hint_state_error']");

        private UIElement _eyeIcon = new UIElement(Common.Enums.FindBy.XPath, "//button[@title='Показать текст пароля']");

        private UIElement _previousStepControl = new UIElement(Common.Enums.FindBy.XPath, "//a[@data-t='backpane']");

        private UIElement _currentAccountControl = new UIElement(Common.Enums.FindBy.XPath, "//a[@class='CurrentAccount']");

        private UIElement _forgotLoginForm = new UIElement(Common.Enums.FindBy.XPath, "//form[@class='UserEntryFlow-form']");

        private UIElement _qrCodeForm = new UIElement(Common.Enums.FindBy.XPath, "//div[@class='passp-auth-content']");

        private UIElement _forgotPasswordForm = new UIElement(Common.Enums.FindBy.XPath, "//form[@class='passp-normal_margin-form']");
        
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static UIElement PrimarySocialNetwork(string primaryValue) => new UIElement(Common.Enums.FindBy.XPath, $"//button[@data-t='provider:primary:{primaryValue}']");

        public static UIElement SecondarySocialNetwork(string secondaryValue) => new UIElement(Common.Enums.FindBy.XPath, $"//button[@data-t='provider:secondary:{secondaryValue}']");        

        public void FillInLoginInput(string value)
        {
            logger.Debug("Fill In Login Input");
            _loginInput.SendKeys(value);
        }

        public void FillInPasswordInput(string value)
        {
            logger.Debug("Fill In Password Input");
            _passwordInput.SendKeys(value);
        }
        
        public string GetPersonalInfo()
        {
            logger.Debug("Get Personal Info");
            string FirstName = _personalInfoFirstName.Text;
            string LastName = _personalInfoLastName.Text;
            string PersonalInfo = FirstName + " " + LastName;
            return PersonalInfo;
        }            

        public void LogIn()
        {
            logger.Debug("Fill In Login Input");
            FillInLoginInput(Constants.login);
            ClickLogInButton();
            logger.Debug("Fill In Password Input");
            FillInPasswordInput(Constants.password);
            ClickLogInButton();
        }
                
        public void LogInWithGoogle(string gmaillogin, string gmailpassword)
        {
              logger.Debug("Log in with google");
              _iconGoogle.Click();
              WebDriverFactory.SwitchToNewWindow();
              _loginInputGoogle.SendKeys(gmaillogin);
              _loginNextButtonGoogle.Click();
              _passwordInputGoogle.ConfirmElementDisplayed();
              _passwordInputGoogle.SendKeys(gmailpassword);
              _passwordNextButtonGoogle.Click();
              WebDriverFactory.SwitchToFirstWindow();
        }      

        public string GetErrorText()
        {
            logger.Debug("Get Error text");
            _errorText.ConfirmTextNotNull();
            return _errorText.Text;
        }

        public void ClickLogInButton()
        {
            logger.Debug("Click Login Button");
            _logInButton.Click();
        }
               
        public string NavigateRegistationPage()
        {
            logger.Debug("Open Registation Page");
            _registrationButton.Click();
            return WebDriverFactory.Driver.Title;  
        }

        public bool NavigateForgotLoginForm()
        {
            logger.Debug("Open Forgot Login Page");
            _forgotLoginLink.Click();
            return _forgotLoginForm.Displayed;
        }           

        public bool ClickQrCodeButton()
        {
            logger.Debug("Open Login with QR-code Page");
            _qrCodeButton.Click();
            return _qrCodeForm.Displayed;
        }

        public bool GetPrimarySocial(string primaryValue)
        {
            logger.Debug("Get Primary Social Network");
            return PrimarySocialNetwork(primaryValue).Displayed;
        }

        public bool GetSecondarySocial(string secondaryValue)
        {
            logger.Debug("Get Primary Secondary Network");
            return SecondarySocialNetwork(secondaryValue).Displayed;
        }

        public void GetSecondarySocialNetworks()
        {
            logger.Debug("Show Secondary Networks");
            _iconMore.Click();
        }

        public bool NavigateForgotPasswordForm()
        {
           logger.Debug("Open Forgot Password Page");
           _forgotPasswordLink.Click();
           return _forgotPasswordForm.Displayed;           
        }                 

        public string ClickEyeControl()
        {
            logger.Debug("Click Show Password control");
            _eyeIcon.Click();
            return _passwordInput.GetAttribute("type");
        }

        public string ClickBackControl()
        {
            logger.Debug("Click Back control");
            _previousStepControl.Click();
            return _loginInput.GetAttribute("value");
        }
        
        public string ClickCurrentAccountControl()
        {
            logger.Debug("Click Current Account control");
            _currentAccountControl.Click();
            return _loginInput.GetAttribute("value");
        }
        
    }
}
