using Yandex_practice.WrapperFactory;
using OpenQA.Selenium;
using Selenium.Community.PageObjects;
using Yandex_practice.TestConfig;
using NLog;

namespace Yandex_practice.PageObjects
{
    public class AuthenticationPage
    {   
        [FindsBy(how: How.XPath, @using: "//a[@class='control link link_theme_normal passp-auth-header-link passp-auth-header-link_visible']")]
        private IWebElement _registrationLink;

        [FindsBy(how: How.XPath, @using: "//a[@class='control link link_theme_normal passp-auth-header-link passp-auth-header-link_visible']")]
        private IWebElement _otherAccountLink;

        [FindsBy(how: How.XPath, @using: "//input[@id='passp-field-login']")]
        private IWebElement _loginInput;

        [FindsBy(how: How.XPath, @using: "//input[@id='passp-field-passwd']")]
        private IWebElement _passwordInput;

        [FindsBy(how: How.XPath, @using: "//a[@class='control link link_theme_normal'][1]")]
        private IWebElement _forgotLoginLink;

        [FindsBy(how: How.XPath, @using: "//a[@class='control link link_theme_normal link_pseudo_yes']")]
        private IWebElement _forgotPasswordLink;

        [FindsBy(how: How.XPath, @using: "//button[@class='control button2 button2_view_classic button2_size_l button2_theme_action button2_width_max button2_type_submit passp-form-button']")]
        private IWebElement _logInButton;

        [FindsBy(how: How.XPath, @using: "//button[@class='control button2 button2_view_classic button2_size_l button2_theme_action button2_width_max passp-sign-in-button__magic-link']")]
        private IWebElement _qrCodeButton;

        [FindsBy(how: How.XPath, @using: "//a[@class='control button2 button2_view_classic button2_size_l button2_theme_normal button2_width_max button2_type_link passp-form-button']")]
        private IWebElement _registrationButton;

        [FindsBy(how: How.XPath, @using: "//li[@class='passp-social-block__list-item passp-social-block__list-item-vk']")]
        private IWebElement _iconVk;

        [FindsBy(how: How.XPath, @using: "//li[@class='passp-social-block__list-item passp-social-block__list-item-fb']")]
        private IWebElement _iconFacebook;

        [FindsBy(how: How.XPath, @using: "//li[@class='passp-social-block__list-item passp-social-block__list-item-gg']")]
        private IWebElement _iconGoogle;

        [FindsBy(how: How.XPath, @using: "//li[@class='passp-social-block__list-item passp-social-block__list-item_more']")]
        private IWebElement _iconMore;

        [FindsBy(how: How.XPath, @using: "//li[@class='passp-social-block__list-item passp-social-block__list-item-mr passp-social-block__list-item-secondary']")]
        private IWebElement _iconMailRu;

        [FindsBy(how: How.XPath, @using: "//li[@class='passp-social-block__list-item passp-social-block__list-item-ok passp-social-block__list-item-secondary']")]
        private IWebElement _iconOk;

        [FindsBy(how: How.XPath, @using: "//li[@class='passp-social-block__list-item passp-social-block__list-item-tw passp-social-block__list-item-secondary']")]
        private IWebElement _iconTwitter;

        [FindsBy(how: How.XPath, @using: "//div[@class='personal-info__first']")]
        private IWebElement _personalInfoFirstName;

        [FindsBy(how: How.XPath, @using: "//div[@class='personal-info__last']")]
        private IWebElement _personalInfoLastName;

        [FindsBy(how: How.XPath, @using: "//input[@type='email']")]
        private IWebElement _loginInputGoogle;

        [FindsBy(how: How.XPath, @using: "//div[@id='identifierNext']")]
        private IWebElement _loginNextButtonGoogle;

        [FindsBy(how: How.XPath, @using: "//div[@id='passwordNext']")]
        private IWebElement _passwordNextButtonGoogle;

        [FindsBy(how: How.XPath, @using: "//input[@type='password']")]
        private IWebElement _passwordInputGoogle;

        [FindsBy(how: How.XPath, @using: "//div[@class='passp-form-field__error']")]
        private IWebElement _errorText;

        [FindsBy(how: How.XPath, @using: "//span[@class='passp-password-field__eye passp-password-field__eye_closed passp-password-field__eye_hidden']")]
        private IWebElement _eyeIcon;

        [FindsBy(how: How.XPath, @using: "//a[@class='control link link_theme_normal passp-previous-step-button']")]
        private IWebElement _previousStepControl;

        [FindsBy(how: How.XPath, @using: "//a[@class='control link link_theme_normal passp-current-account passp-current-account_without-login']")]
        private IWebElement _currentAccountControl;

        [FindsBy(how: How.XPath, @using: "//div[@class='login-restore__wrapper']")]
        private IWebElement _forgotLoginForm;

        [FindsBy(how: How.XPath, @using: "//div[@class='passp-auth-screen passp-magic-page passp-route-enter-done']")]
        private IWebElement _qrCodeForm;

        [FindsBy(how: How.XPath, @using: "//div[@class='passp-route-forward']")]
        private IWebElement _forgotPasswordForm;

        private static Logger logger = LogManager.GetCurrentClassLogger();

        public void LogIn()
        {
            _loginInput.SendKeys(Constants.login);
            _logInButton.Click();
            logger.Debug("Fill in login");
            _passwordInput.SendKeys(Constants.password);
            _logInButton.Click();
            logger.Debug("Fill in password");
        }

        public string GetPersonalInfoFirstName()
        {
            logger.Debug("Get First name");
            return _personalInfoFirstName.Text;
        }

        public string GetPersonalInfoLastName()
        {
            logger.Debug("Get Last name");
            return _personalInfoLastName.Text;
        }
        
        public void LogInWithGoogle()
        {
              _iconGoogle.Click();
              WebDriverFactory.SwitchToNewWindow();
              _loginInputGoogle.SendKeys(Constants.gmail);
              _loginNextButtonGoogle.Click();
              _passwordInputGoogle.SendKeys(Constants.password);
              _passwordNextButtonGoogle.Click();
              WebDriverFactory.SwitchToOriginalWindow();              
        }

        public string GetErrorText()
        {
            return _errorText.Text;
        }

        public void FillInLoginValid()
        {
            _loginInput.SendKeys(Constants.login);
        }

        public void FillInPasswordValid()
        {
            _passwordInput.SendKeys(Constants.password);
        }

        public void ClickLogInButton()
        {
            _logInButton.Click();
        }

        public void FillInLoginInvalid()
        {
            _loginInput.SendKeys(Constants.invalidlogin);
        }

        public void FillInPasswordInvalid()
        {
            _passwordInput.SendKeys(Constants.invalidpassword);
        }

        public void FollowRegistationLink()
        {
            _registrationLink.Click();                     
        }

        public void ClickRegistationButton()
        {
            _registrationButton.Click();                       
        }

        public bool GetForgotLoginForm()
        {
            return _forgotLoginForm.Displayed;
        }
        
        public void FollowForgotLoginLink()
        {
            _forgotLoginLink.Click();                     
        }

        public bool GetQrCodeForm()
        {
            return _qrCodeForm.Displayed;
        }

        public void ClickQrCodeButton()
        {
            _qrCodeButton.Click();                       
        }

        public bool GetVkIcon()
        {
            return _iconVk.Displayed;
        }

        public bool GetFacebookIcon()
        {
            return _iconFacebook.Displayed;
        }

        public bool GetGoogleIcon()
        {
            return _iconGoogle.Displayed;
        }

        public bool GetMailRuIcon()
        {
            return _iconMailRu.Displayed;
        }

        public bool GetOkIcon()
        {
            return _iconOk.Displayed;
        }

        public bool GetTwitterIcon()
        {
            return _iconTwitter.Displayed;
        }

        public void OpenMoreSocialNetworksControls()
        {
            _iconMore.Click();
        }

        public bool GetForgotPasswordForm()
        {
            return _forgotPasswordForm.Displayed;
        }

        public void FollowFogotPasswordLink()
        {            
            _forgotPasswordLink.Click();                     
        }

        public string GetPasswordInputType()
        {
            return _passwordInput.GetAttribute("type");
        }

        public void ClickEyeControl()
        {           
            _eyeIcon.Click();           
        }

        public void ClickBackControl()
        {            
            _previousStepControl.Click();           
        }

        public string GetLoginInputValue()
        {
            return _loginInput.GetAttribute("value");
        }

        public void ClickCurrentAccountControl()
        {
            _currentAccountControl.Click();                      
        }

        public void ClickOtherAccountControl()
        {
            _otherAccountLink.Click();            
        }
    }
}
