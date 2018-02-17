using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using System.Linq;
using CCXUITestsDemo.Model;
using log4net;
using Microsoft.Test.VisualVerification;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;
using System.Globalization;
using OpenQA.Selenium.Remote;
using System.Threading;
using System.Diagnostics;

namespace CCXUITestsDemo
{
    [TestClass]
    public class MainTests
    {
        private static ILog logger = LogManager.GetLogger(typeof(MainTests));

        IWebDriver driver;
        private static TestContext testContext;
        public static string globalTenderTitle = "";
        public static string globalTenderRefNum = "";
        private static int waitForAjax = 3000;
        private static string browser = "";
        private static string startUrl = "";
        public static Boolean tenderPart_Information = false;
        public static Boolean tenderPart_Destinations = false;
        public static Boolean tenderPart_TermsAndConditions = false;
        public static Boolean tenderPart_UploadsAndComments = false;
        public static Boolean tenderPart_BiddingMatrix = false;
        public static Boolean tenderPart_QuestionsAndAnswers = false;
        public static String enabledInformation = "";
        public static String enabledDestinations = "";
        public static String enabledTermsAndConditiops = "";
        public static String enabledBiddingMatrix = "";
        public static String enabledUploadsAndComments = "";
        public static String enabledQuestionsAndAnswers = "";
        public static IWebElement termsAndConditions;
        public static IWebElement biddingMatrix;
        public static String tenderEndTime = "";
        public static Boolean analysisPart_Information = false;
        public static Boolean analysisPart_DefaultAnalysis = false;
        public static Boolean analysisPart_OverviewCarriers = false;
        public static Boolean analysisPart_OverviewScenarios = false;
        public static Boolean analysisPart_DefaultScenario = false;
        public static String enabledAnalysis = "";
        public static String enabledDefaultAnalysis = "";
        public static String enabledOverviewCarriers = "";
        public static String enabledOverviewScenarios = "";
        public static String enabledDefaultScenario = "";
        public static IWebElement overviewCarriers;
        public static IWebElement overviewScenarios;
        public static IWebElement defaultScenario;
        public static IWebElement btnRefresh_OverviewCarriers;
        public static IWebElement btnUnitPrice_OverviewCarriers;
        public static IWebElement btnAnalysis_OverviewCarriers;
        public static IWebElement btnShowCents_OverviewCarriers;
        public static IWebElement btnAmount_OverviewCarriers;
        public static IWebElement btnRefresh_OverviewScenarios;
        public static IWebElement btnNewScenario_OverviewScenarios;
        public static IWebElement btnUnitPrice_OverviewScenarios;
        public static IWebElement btnNoComparison_OverviewScenarios;
        public static IWebElement btnExportToXLS_OverviewScenarios;
        public static IWebElement btnAnalysis_DefaultScenario;
        public static IWebElement btnRefresh_DefaultScenario;
        public static IWebElement btnVisibleFields_DefaultScenario;


       
        


        public LogInModel CurrentUser { get; set; }

        public TenderModel CreateTenderModel { get; set; }
        public string TenderTiltle_Step1 { get; set; }


        [ClassInitialize]
        public static void SetupTests(TestContext context)
        {            
            testContext = context;
            log4net.Config.XmlConfigurator.Configure();
        }

        [TestInitialize]
        public void TestChromeSetup()
        {
            startUrl = testContext.Properties["Url"].ToString();
            browser = testContext.Properties["TargetBrowser"].ToString();
        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Close();
            driver.Quit();
        }

        #region Tests

        [TestMethod]
        public void Test_LogIn()
        {
            logger.Info("Start Test_LogIn test");
            switch (browser)
            {
                case "ie":
                    RunIELoginTest();
                    break;
                case "ff":
                    RunFireFoxLoginTest();
                    break;
                default:
                    RunChromeLoginTest();
                    break;
            };
            //driver.SwitchTo().Frame(driver.FindElements(By.TagName("iframe"))[0]);
            //FindAndOpenTenderWizard(_tenderRef);
            //driver.SwitchTo().DefaultContent();
            //NavigateOnTenderWizardToParticularStepAndCheckResult();
        }

        [TestMethod]
        public void Test_Create_Tender()
        {
            logger.Info("Start Test_Create_Tender test");
            switch (browser)
            {
                case "ie":
                    RunIECreateTenderTest();
                    break;
                case "ff":
                    RunFireFoxCreateTenderTestt();
                    break;
                default:
                    RunChromeCreateTenderTest();
                    break;
            };
        }

        //[TestMethod]
        //public void Test_Create_Master_Screenshot()
        //{
        //    SetupChromeEnvironment();
        //    LogOut();
        //    SetUpVerifyScreensTestSettings();
        //    CloseCompatibilityModeWindow();
        //    LogInCurrentUser();
        //    SelectEnglishLanguage();
        //    WaitForLoad(driver);

        //    driver.SwitchTo().Frame(driver.FindElements(By.TagName("iframe"))[0]);

        //    IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

        //    var filterBtn = driver.FindElement(By.XPath("//*[@id='filterButton-btnEl']"));
        //    executor.ExecuteScript("arguments[0].click();", filterBtn);

        //    var filterTitle = driver.FindElement(By.XPath("//*[@id='filtertdrInfo-inputEl']"));
        //    filterTitle.SendKeys("VLD_#rc0.1.0.3618e_s03_T11");

        //    var applyFilter = driver.FindElement(By.XPath("//*[@id='button-1037-btnEl']"));
        //    executor.ExecuteScript("arguments[0].click();", applyFilter);

        //    WaitForAjax();

        //    executor.ExecuteScript("arguments[0].click();", filterBtn);

        //    Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
        //    ss.SaveAsFile("f:\\temp\\uitests\\master-diff.png", ScreenshotImageFormat.Png);
        //}

        //[TestMethod]
        //public void Test_Create_Master_Create_Tender_First_Step_Screenshot()
        //{
        //    SetupChromeEnvironment();
        //    LogOut();
        //    SetUpVerifyScreensTestSettings();
        //    CloseCompatibilityModeWindow();
        //    LogInCurrentUser();
        //    SelectEnglishLanguage();
        //    WaitForLoad(driver);

        //    driver.SwitchTo().Frame(driver.FindElements(By.TagName("iframe"))[0]);

        //    System.Threading.Thread.Sleep(5000);

        //    IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

        //    var filterBtn = driver.FindElement(By.XPath("//*[@id='filterButton-btnEl']"));
        //    executor.ExecuteScript("arguments[0].click();", filterBtn);
        //    var filterRef = driver.FindElement(By.XPath("//*[@id='filterRef-inputEl']"));
        //    filterRef.SendKeys(CurrentUser.VerifyScreensTenderRef);
        //    var applyFilter = driver.FindElement(By.XPath("//*[@id='button-1037-btnEl']"));
        //    executor.ExecuteScript("arguments[0].click();", applyFilter);
        //    WaitForAjax();
        //    executor.ExecuteScript("arguments[0].click();", filterBtn);

        //    driver.SwitchTo().DefaultContent();

        //    OpenCreateTenderWindow();



        //    string workPath = testContext.Properties["ScreenPath"].ToString();

        //    Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
        //    ss.SaveAsFile("f:\\temp\\uitests\\master_shipper_create_tender_1_step.png", ScreenshotImageFormat.Png);
        //}

        [TestMethod]
        public void Test_Verify_Shipper_All_Tender_Screen()
        {
            logger.Info("Start Test_Verify_Shipper_All_Tender_Screen Test.");
            SetupChromeEnvironment();
            LogOut();
            SetUpVerifyScreensTestSettings();
            CloseCompatibilityModeWindow();
            LogInCurrentUser();
            SelectEnglishLanguage(9, "//iframe[contains(@src,'/TenderList/ShipperGridView')]");
            WaitForLoad(driver);

            System.Threading.Thread.Sleep(5000);

            driver.SwitchTo().Frame(driver.FindElements(By.TagName("iframe"))[0]);
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            var filterBtn = driver.FindElement(By.XPath("//*[@id='filterButton-btnEl']"));
            executor.ExecuteScript("arguments[0].click();", filterBtn);
            var filterRef = driver.FindElement(By.XPath("//*[@id='filterRef-inputEl']"));
            filterRef.SendKeys(CurrentUser.VerifyScreensTenderRef);
            var applyFilter = driver.FindElement(By.XPath("//*[@id='button-1037-btnEl']"));
            executor.ExecuteScript("arguments[0].click();", applyFilter);
            WaitForAjax();
            executor.ExecuteScript("arguments[0].click();", filterBtn);

            string workPath = testContext.Properties["ScreenPath"].ToString();
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile(Path.Combine(workPath, "actual_shipper_tender_all.png"), ScreenshotImageFormat.Png);

            Snapshot master = Snapshot.FromFile(Path.Combine(workPath, "master_shipper_tender_all.png"));
            Snapshot actual = Snapshot.FromFile(Path.Combine(workPath, "actual_shipper_tender_all.png"));
            Snapshot difference = actual.CompareTo(master);
            SnapshotVerifier v = new SnapshotColorVerifier(Color.Black, new ColorDifference());
            if (v.Verify(difference) == VerificationResult.Fail)
            {
                difference.ToFile(Path.Combine(workPath, "difference_shipper_tender_all.png"), ImageFormat.Png);
            }
        }

        [TestMethod]
        public void Test_Verify_Shipper_Create_Tender_First_Step_Screen()
        {
            logger.Info("Start Test_Verify_Shipper_Create_Tender_First_Step_Screen Test.");
            SetupChromeEnvironment();
            LogOut();
            SetUpVerifyScreensTestSettings();
            CloseCompatibilityModeWindow();
            LogInCurrentUser();
            SelectEnglishLanguage(9, "//iframe[contains(@src,'/TenderList/ShipperGridView')]");
            WaitForLoad(driver);

            System.Threading.Thread.Sleep(5000);

            driver.SwitchTo().Frame(driver.FindElements(By.TagName("iframe"))[0]);
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            var filterBtn = driver.FindElement(By.XPath("//*[@id='filterButton-btnEl']"));
            executor.ExecuteScript("arguments[0].click();", filterBtn);
            var filterRef = driver.FindElement(By.XPath("//*[@id='filterRef-inputEl']"));
            filterRef.SendKeys(CurrentUser.VerifyScreensTenderRef);
            var applyFilter = driver.FindElement(By.XPath("//*[@id='button-1037-btnEl']"));
            executor.ExecuteScript("arguments[0].click();", applyFilter);
            WaitForAjax();
            executor.ExecuteScript("arguments[0].click();", filterBtn);

            string workPath = testContext.Properties["ScreenPath"].ToString();

            driver.SwitchTo().DefaultContent();

            OpenCreateTenderWindow();

            System.Threading.Thread.Sleep(3000);

            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile(Path.Combine(workPath, "actual_shipper_create_tender_1_step.png"), ScreenshotImageFormat.Png);

            Snapshot master = Snapshot.FromFile(Path.Combine(workPath, "master_shipper_create_tender_1_step.png"));
            Snapshot actual = Snapshot.FromFile(Path.Combine(workPath, "actual_shipper_create_tender_1_step.png"));
            Snapshot difference = actual.CompareTo(master);
            SnapshotVerifier v = new SnapshotColorVerifier(Color.Black, new ColorDifference());
            if (v.Verify(difference) == VerificationResult.Fail)
            {
                difference.ToFile(Path.Combine(workPath, "difference_shipper_create_tender_1_step.png"), ImageFormat.Png);
            }
        }

        [TestMethod]
        public void Test_Create_Shipper_Create_Tender_First_Step_Screen()
        {
            SetupChromeEnvironment();
            LogOut();
            SetUpVerifyScreensTestSettings();
            CloseCompatibilityModeWindow();
            LogInCurrentUser();
            SelectEnglishLanguage(9, "//iframe[contains(@src,'/TenderList/ShipperGridView')]");
            WaitForLoad(driver);

            System.Threading.Thread.Sleep(5000);

            driver.SwitchTo().Frame(driver.FindElements(By.TagName("iframe"))[0]);
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            var filterBtn = driver.FindElement(By.XPath("//*[@id='filterButton-btnEl']"));
            executor.ExecuteScript("arguments[0].click();", filterBtn);
            var filterRef = driver.FindElement(By.XPath("//*[@id='filterRef-inputEl']"));
            filterRef.SendKeys(CurrentUser.VerifyScreensTenderRef);
            var applyFilter = driver.FindElement(By.XPath("//*[@id='button-1037-btnEl']"));
            executor.ExecuteScript("arguments[0].click();", applyFilter);
            WaitForAjax();
            executor.ExecuteScript("arguments[0].click();", filterBtn);

            string workPath = testContext.Properties["ScreenPath"].ToString();

            driver.SwitchTo().DefaultContent();

            OpenCreateTenderWindow();

            System.Threading.Thread.Sleep(3000);

            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile(Path.Combine(workPath, "master_shipper_create_tender_1_step.png"), ScreenshotImageFormat.Png);
        }

        #endregion

        private void RunTheMeasureMethod(string actionName, Action func)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            func();
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            var res = (double)elapsedMs / 1000;
            if (res > 10)
            {
                logger.Info(string.Format("#Warning '{0}' took quite a long time: {1} sec!", actionName, res.ToString()));
            }
        }
        private static void WaitForLoad(IWebDriver driver, string actionName, int timeoutSec = 15)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var waitForDocumentReady = new WebDriverWait(driver, new TimeSpan(0, 0, timeoutSec));
            waitForDocumentReady.Until((wdriver) => (driver as IJavaScriptExecutor).ExecuteScript("return document.readyState").Equals("complete"));
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            var res = (double)elapsedMs / 1000;
            if (res > 10)
            {
                logger.Info(string.Format("#Warning '{0}' took quite a long time: {1} sec!", actionName, res.ToString()));
            }
        }
        private static void WaitForLoad(IWebDriver driver, int timeoutSec = 15)
        {
            var waitForDocumentReady = new WebDriverWait(driver, new TimeSpan(0, 0, timeoutSec));
            waitForDocumentReady.Until((wdriver) => (driver as IJavaScriptExecutor).ExecuteScript("return document.readyState").Equals("complete"));
        }
        private void WaitForAjax()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitForAjax));
            wait.Until(d => (bool)(d as IJavaScriptExecutor).ExecuteScript("return !Ext.Ajax.isLoading();"));
            System.Threading.Thread.Sleep(3000);
        }
        private void WaitForAjax(string actionName)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitForAjax));
            wait.Until(d => (bool)(d as IJavaScriptExecutor).ExecuteScript("return !Ext.Ajax.isLoading();"));
            // System.Threading.Thread.Sleep(1000);
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            var res = (double)elapsedMs / 1000;
            if (res > 10)
            {
                logger.Info(string.Format("#Warning '{0}' took quite a long time: {1} sec!", actionName, res.ToString()));
            }
        }


        private void explicitWaitsUntilElementLocated(int maxSeconds, String elementXPath, String PageName)
        {

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(maxSeconds)); // seconds

            var startTime = System.Diagnostics.Stopwatch.StartNew();

            try
            {

                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(elementXPath)));

                startTime.Stop();
                var elapsedTimeInSeconds = startTime.Elapsed.Milliseconds;
                var res = (double)elapsedTimeInSeconds / 1000;


                logger.Info("TOTAL TIME that " + PageName + " page was loading: " + res.ToString() + " seconds.");
                return;

            }
            catch (Exception e)
            {
                logger.Warn(PageName + " page has timed out after " + maxSeconds + " seconds: " + e.Message);

            }
        }



        private void waitTillDescendentElementsAvailable(int maxSeconds, String XPath, String webElementAttribute, String attributeValueToSearch, String PageName)
        {
            var startTime = System.Diagnostics.Stopwatch.StartNew();

            for (int i = 1; i <= maxSeconds; i++)
            {

                //Select the parent web element
                IList<IWebElement> elm = driver.FindElements(By.XPath(XPath));

                System.Threading.Thread.Sleep(2000);

                //Loop the selected web element descendants
                foreach (IWebElement el1 in elm)
                {
                    String paramName = el1.GetAttribute(webElementAttribute);
                    Console.WriteLine("Object parameter name: " + paramName);

                    if (paramName.Contains(attributeValueToSearch))
                    {

                        startTime.Stop();
                        var elapsedTimeInSeconds = startTime.Elapsed.Seconds;


                        logger.Info("TOTAL TIME that the " + PageName + " page was loading: " + elapsedTimeInSeconds + " seconds.");

                        return;


                    }
                    else
                    {
                        System.Threading.Thread.Sleep(1000);
                    }
                }
            }
            throw new Exception("Timed out on " + PageName + " after " + maxSeconds + " seconds");
        }



        private void LogOut()
        {
            driver.SwitchTo().DefaultContent();

            if (IsElementExists(By.XPath("//*[@id='btnLogout-btnInnerEl']")))
            {
                IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
                var btn = driver.FindElement(By.XPath("//*[@id='btnLogout-btnInnerEl']"));
                executor.ExecuteScript("arguments[0].click();", btn);
                System.Threading.Thread.Sleep(3000);
            }
        }
        private void CheckIsShipperTenderAllTabExist()
        {
            var tab = driver.FindElement(By.XPath("//*[@id='tab-1020-btnInnerEl']"));
            Assert.AreEqual(tab.Text, "Shipper tenders(all)");
        }
        private void SelectEnglishLanguage(int num, String gridXPath)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            Actions action = new Actions(driver);

            driver.SwitchTo().DefaultContent();


            //Checking whether English version is selected. If not - then select English version
            if (!driver.FindElement(By.XPath("//*[@id='btnLogout-btnInnerEl']")).Text.Contains("Logout"))
            {
                try
                {
                    //var acctBtn = driver.FindElement(By.XPath("//*[@id='mmAccount-btnEl']"));
                    //var acctBtn = driver.FindElement(By.XPath("//*[@id='mmCtl24-btnEl']"));
                    var acctBtn = driver.FindElement(By.XPath("//div[@id='TopToolbar-targetEl']/div["+num+"]/em[@class='x-btn-arrow x-btn-arrow-right']/button[@class='x-btn-center']"));
                    var watch0 = Stopwatch.StartNew();
                    executor.ExecuteScript("arguments[0].click();", acctBtn);
                    //Wait till page is reloaded
                    watch0.Stop();
                    var elapsedMs0 = watch0.ElapsedMilliseconds;
                    var res0 = (double)elapsedMs0 / 1000;
                    if (res0 > 10)
                    {
                        logger.Info(string.Format("#Warning. It took quite a long time: {0} sec for opening LANGUAGE menu dropdown.", res0.ToString()));
                    }

                                        
                    explicitWaitsUntilElementLocated(15, "//div[@class='x-panel x-layer x-panel-default x-menu']", "Language selection dropdown items");
                    Thread.Sleep(1000);
                    /*
                    var menuElement = driver.FindElement(By.XPath(menuElementXPath));
                    var watch1 = Stopwatch.StartNew();
                    action.MoveToElement(menuElement).Perform();
                    watch1.Stop();
                    var elapsedMs1 = watch1.ElapsedMilliseconds;
                    var res1 = (double)elapsedMs1 / 1000;
                    if (res1 > 10)
                    {
                        logger.Info(string.Format("#Warning. It took quite a long time: {0} sec for opening LANGUAGE item in ACCOUNT menu dropdown.", res1.ToString()));
                    }
                    Thread.Sleep(1000);*/

                    var eng = driver.FindElement(By.XPath("//*[@id='2-itemEl']"));
                    Thread.Sleep(2000);
                    executor.ExecuteScript("arguments[0].click();", eng);

                    

                    //Waiting till the Shipper's main window is downloaded
                   // explicitWaitsUntilElementLocated(20, "//iframe[@name='mmCtl13_IFrame']", "ALL TENDERS");
                      explicitWaitsUntilElementLocated(20, gridXPath, "ALL TENDERS TAB after changing to English");
                    

                    //When using an iframe, you will first have to switch to the iframe, before selecting the elements of that iframe.
                    //driver.SwitchTo().Frame("mmCtl13_IFrame");
                    driver.SwitchTo().Frame(driver.FindElement(By.XPath(gridXPath)));


                    //Waiting till the 'All tenders' grid is downloaded in the Shipper's main window
                    explicitWaitsUntilElementLocated(20, "//*[@class='row-imagecommand   icon-report ']", "All TENDER's GRID after changing to English");

                    //Exit iframe to have access to the main window's web-elements
                    driver.SwitchTo().DefaultContent();
                    


                    logger.Info("GUI language has been changed to ENGLISH.");
                }
                catch (Exception e1) {
                    logger.Error("UNABLE to change GUI language to ENGLISH: " + e1.Message);
                    driver.Quit();
                }
            }
        }
        private void CheckChromeBrowserSettings()
        {
            // check browser version
            string version = ((ChromeDriver)driver).Capabilities.Version;
            int ver = 0;
            Int32.TryParse(version.Substring(0, version.IndexOf(".")), out ver);
            Assert.IsTrue(ver > 41);
        }
        private void CheckIEBrowserSettings()
        {
            // check browser version
            string version = ((InternetExplorerDriver)driver).Capabilities.Version;
            int ver = 0;
            Int32.TryParse(version, out ver);
            Assert.IsTrue(ver >= 11);
        }
        private void CheckFireFoxBrowserSettings()
        {
            // check browser version
            string version = ((FirefoxDriver)driver).Capabilities.GetCapability("browserVersion").ToString();
            int ver = 0;
            Int32.TryParse(version.Substring(0, version.IndexOf(".")), out ver);
            Assert.IsTrue(ver >= 50);
        }
        private void CloseCompatibilityModeWindow()
        {
            if (IsElementExists(By.XPath("//*[@id='button-1042-btnEl']")))
            {
                var btn = driver.FindElement(By.XPath("//*[@id='button-1042-btnEl']"));
                if (btn.Displayed)
                    btn.Click();

                System.Threading.Thread.Sleep(1000);
            }
        }
        private bool IsElementExists(By by)
        {
            var items = driver.FindElements(by);
            return items.Count > 0;
        }
        public void SetupIEEnvironment()
        {
            InternetExplorerOptions opt = new InternetExplorerOptions();
            driver = new InternetExplorerDriver(opt);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            RunTheMeasureMethod("Go to the start URL", delegate () { driver.Navigate().GoToUrl(startUrl); });

            WaitForLoad(driver, "LOGIN page", 20);

        }
        public void SetupFireFoxEnvironment()
        {
            FirefoxOptions opt = new FirefoxOptions();
            opt.SetPreference("intl.accept_languages", "en");
            driver = new FirefoxDriver(opt);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            RunTheMeasureMethod("Go to the start URL", delegate () { driver.Navigate().GoToUrl(startUrl); });
        }
        public void SetupChromeEnvironment()
        {
            ChromeOptions opt = new ChromeOptions();
            opt.AddArguments("---lang=en");
            opt.AddArguments("test-type");
            opt.AddArguments("start-maximized");
            opt.AddArguments("--disable-extensions");
            opt.AddArguments("no-sandbox");
            driver = new ChromeDriver(opt);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            RunTheMeasureMethod("Go to the start URL", delegate () { driver.Navigate().GoToUrl(startUrl); });
            driver.Navigate().GoToUrl(startUrl);
        }
        private void CheckStartLoadingForm()
        {
            bool isCompatibilityWindowShown = IsElementExists(By.XPath("//*[@id='CompatibilityWindow-body']"));
            Assert.IsFalse(isCompatibilityWindowShown);

            bool isLoginWindowShown = IsElementExists(By.XPath("//*[@id='LoginWindow-body']"));
            Assert.IsTrue(isCompatibilityWindowShown);
        }
        private void LogInCurrentUser()
        {
            BuildShipperUser("s03", "admin");
            var txtUserName = driver.FindElement(By.XPath("//*[@id='txtUsername-inputEl']"));
            var txtPassword = driver.FindElement(By.XPath("//*[@id='txtPassword-inputEl']"));
            var btn = driver.FindElement(By.XPath("//*[@id='LoginButton-btnEl']"));

            txtUserName.Clear();
            txtUserName.SendKeys(CurrentUser.UserName);
            txtPassword.Clear();
            txtPassword.SendKeys(CurrentUser.Password);

            btn.Click();


            //Waiting till the Shipper's main window is downloaded
            //explicitWaitsUntilElementLocated(20, "//iframe[@name='mmCtl13_IFrame']", "ALL TENDERS");
            explicitWaitsUntilElementLocated(20, "//iframe[contains(@src,'/TenderList/ShipperGridView')]", "ALL TENDERS TAB on Shipper's side");


            //When using an iframe, you will first have to switch to the iframe, before selecting the elements of that iframe.
            //driver.SwitchTo().Frame("mmCtl13_IFrame");
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[contains(@src,'/TenderList/ShipperGridView')]")));
                                    

            //Waiting till the 'All tenders' grid is downloaded in the Shipper's main window
            explicitWaitsUntilElementLocated(20, "//*[@class='row-imagecommand   icon-report ']", "ALL TENDERS GRID on Shipper's side");

            //Exit iframe to have access to the main window's web-elements
            driver.SwitchTo().DefaultContent();


            //var watch = System.Diagnostics.Stopwatch.StartNew();
            // btn.Click();
            /*watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            var res = (double)elapsedMs / 1000;
            if (res > 10)
            {
                logger.Info(string.Format("#Warning '{0}' took quite a long time: {1} sec!", "Log In Click", res.ToString()));
            }*/
        }
        private void CreateTender()
        {
            driver.SwitchTo().DefaultContent();
            OpenCreateTenderWindow();
            WaitForAjax("Create tender");
            CreateTenderProcessStep1();
            WaitForAjax();
            CreateTenderProcessStep2();
            WaitForAjax();
            CreateTenderProcessStep3();
            WaitForAjax();
            CreateTenderProcessStep4();
            WaitForAjax();
            CreateTenderProcessStep5();
            WaitForAjax();
            CreateTenderProcessStep6();
            WaitForAjax();
            CreateTenderProcessStep7();
            WaitForAjax();
            CreateTenderProcessStep8();
            WaitForAjax();
            CreateTenderProcessStep9();
            WaitForAjax();
        }


        private void GetCreatedTenderREF()
        {
            // use js executor as click have problem in IE
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

            driver.SwitchTo().DefaultContent();

            //When using an iframe, you will first have to switch to the iframe, before selecting the elements of that iframe.
            //driver.SwitchTo ( ).Frame ("mmCtl13_IFrame");
            driver.SwitchTo().Frame(0);

            //Click on "Filter Your Search" button
            var btnFilter = driver.FindElement(By.XPath("//*[@id='filterButton-btnEl']"));
            executor.ExecuteScript("arguments[0].click();", btnFilter);

            Thread.Sleep(2000);

            //Enter tender's title into search field
            var txtFilterTenderName = driver.FindElement(By.XPath("//*[@id='filtertdrInfo-inputEl']"));
            txtFilterTenderName.SendKeys(globalTenderTitle);  //TenderTiltle_Step1

            Thread.Sleep(1000);

            //Click on "Apply" button to search the tender with the requested title
            var btnFilterApply = driver.FindElement(By.XPath("//*[@id='button-1037-btnInnerEl']"));
            executor.ExecuteScript("arguments[0].click();", btnFilterApply);

            Thread.Sleep(3000);

            //Get the tender's refernce value from the "Reference" column
            globalTenderRefNum = driver.FindElement(By.XPath("//div[@id='ShipperGridPanel-body']/div[@class='x-grid-view x-fit-item x-grid-view-default x-unselectable']/table/tbody/tr[2]/td/div[@class='x-grid-rowwrap-div']/table/tbody/tr/td[2]/div")).Text;

            Console.WriteLine("Tender REF# is: " + globalTenderRefNum);

            //Get the status of found tender
            var iconTenderStatus = driver.FindElement(By.XPath("//div[@id='ShipperGridPanel-body']/div/table/tbody/tr[2]/td/div/table/tbody/tr/td[1]/div/img"));
            System.Threading.Thread.Sleep(1000);
            string tenderStatus = iconTenderStatus.GetAttribute("title");
            //Console.WriteLine("Tender's status after publishing by shipper is :" + tenderStatus);

            //If tender's status is "Waiting for acceptance by Admin" then proceed
            if (!tenderStatus.Equals("Waiting for acceptance by Admin"))
            {
                logger.Warn("After publishing by the shipper the tender's status should be 'WAITING FOR ACCEPTANCE BY ADMIN'. However, current tender's status is " + tenderStatus.ToUpper());
                driver.Quit();
            }

            }

        private void OpenCreateTenderWindow()
        {
            // use js executor as click have problem in IE
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            var menu = driver.FindElement(By.XPath("//*[@id='mmTenders-btnInnerEl']"));
            executor.ExecuteScript("arguments[0].click();", menu);
            //menu.Click();
            var createLink = driver.FindElement(By.XPath("//*[@id='mmStartTender']"));
            executor.ExecuteScript("arguments[0].click();", createLink);
            //createLink.Click();
        }
        private void CreateTenderProcessStep1()
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

            var headerDiv = driver.FindElement(By.Id("tenderWizardDlg_header-innerCt"));
            var fullScreen = headerDiv.FindElements(By.TagName("div"))[0].FindElements(By.TagName("img"))[0];
            executor.ExecuteScript("arguments[0].click();", fullScreen);

            var title = driver.FindElement(By.XPath("//*[@id='Title-inputEl']"));
            var stepTitle = driver.FindElement(By.XPath("//*[@id='tenderWizardDlg_header_hd-textEl']"));
            var num = driver.FindElement(By.XPath("//*[@id='TenderNumber-inputEl']"));
            var internalMemo = driver.FindElement(By.XPath("//*[@id='InternalTitle-inputEl']"));
            var startDate = driver.FindElement(By.XPath("//*[@id='StartTenderDate-inputEl']"));
            var endDate = driver.FindElement(By.XPath("//*[@id='EndTenderDate-inputEl']"));
            var startCollaborationitle = driver.FindElement(By.XPath("//*[@id='StartCollaboration-inputEl']"));
            var finishCollaboration = driver.FindElement(By.XPath("//*[@id='FinishCollaboration-inputEl']"));

            var startTime = driver.FindElement(By.XPath("//*[@id='StartTenderTime-inputEl']"));
            var endTime = driver.FindElement(By.XPath("//*[@id='EndTenderTime-inputEl']"));

            title.SendKeys(CreateTenderModel.TenderTiltle_Step1);
            globalTenderTitle = CreateTenderModel.TenderTiltle_Step1;
            Console.WriteLine("globalTenderTitle variable was assigned value: " + globalTenderTitle);

            num.SendKeys(CreateTenderModel.TenderNumber_Step1);
            internalMemo.SendKeys(CreateTenderModel.InternalMemo_Step1);

            Console.WriteLine("CreateTenderModel.TenderTiltle_Step1 = " + CreateTenderModel.TenderTiltle_Step1);
            Assert.IsTrue(stepTitle.Text.Contains("Starting new tender - Basic Information"));


            //Simply set the "Start of Tendering" date to yesterday
            startDate.Clear();
            startDate.SendKeys(incrementYYmmDDhhMMssBy1(0, 0, -1, 0, 0, 0, "MM/dd/yyyy"));
            System.Threading.Thread.Sleep(100);

            //Providing current date in the "End of tendering" calendar
            endDate.Clear();
            endDate.SendKeys(incrementYYmmDDhhMMssBy1(0, 0, 0, 0, 0, 0, "MM/dd/yyyy"));

            System.Threading.Thread.Sleep(100);


            //Provide "Start of collaboration" date which is 7 days later from now
            startCollaborationitle.Clear();
            startCollaborationitle.SendKeys(incrementYYmmDDhhMMssBy1(0, 0, 7, 0, 0, 0, "MM/dd/yyyy"));

            System.Threading.Thread.Sleep(100);


            //Provide "End of collaboration" date which is 37 days later from now
            finishCollaboration.Clear();
            finishCollaboration.SendKeys(incrementYYmmDDhhMMssBy1(0, 0, 27, 0, 0, 0, "MM/dd/yyyy"));

            //endDate.SendKeys(startDate.GetAttribute("value"));
            Thread.Sleep(100);



            //Read default time from the "Start of Tendering" time picker
            IWebElement element2 = driver.FindElement(By.XPath("//*[@id='StartTenderTime-inputEl']"));
            String timeX = element2.GetAttribute("value");


            //Check if the time format AM/PM
            if (timeX.Substring(timeX.Length - 2).Equals("am") || timeX.Substring(timeX.Length - 2).Equals("pm"))
            {
                logger.Info("12 HOURS AM/PM TIME FORMAT DETECTED in the time picker: " + timeX);

                //Read current time from the shipper's dashboard and convert it to AM/PM format
                String timeCurrentTime = getCurrentTimeFromShippersDashboardAndConvert24Hto12H();

                //Initialize empty string variable
                String time1HourFromCurrentTime = "";

                //Getting to string the minutes of the current time
                String timeCurrentMM = timeCurrentTime.Substring(timeCurrentTime.Length - 5, 2);
                System.Diagnostics.Debug.WriteLine("Current minutes: " + timeCurrentMM);
                int timeCurrentMM1 = Int32.Parse(timeCurrentMM);


                //After 50 minutes
                if (timeCurrentMM1 >= 50)
                {

                    //Set time to be 30 + XX minutes from now if less than 10 minutes remaining till the next hour
                    time1HourFromCurrentTime = incrementYYmmDDhhMMssBy2(0, 0, 0, 0, (30 + (60 - timeCurrentMM1)), 0, "hh:mm tt");
                    Console.WriteLine("Time set to be 30 + XX minutes from now as less than 10 minutes remaining till the next hour: " + time1HourFromCurrentTime);

                    //Rounding minutes to 30 or 00
                    time1HourFromCurrentTime = roundingMinutes(time1HourFromCurrentTime);

                    //Change "End of Tendering" date to the next day on the border of two days
                    if (timeCurrentTime.Substring(timeCurrentTime.Length - 2).Equals("PM"))
                    {

                        if (timeCurrentTime.Substring(timeCurrentTime.Length - timeCurrentTime.Length, timeCurrentTime.Length - (timeCurrentTime.Length - 2)).Equals("11"))
                        {

                            //Providing current date in the "End of tendering" calendar
                            try
                            {
                                endDate.Clear();
                                endDate.SendKeys(incrementYYmmDDhhMMssBy1(0, 0, 1, 0, 0, 0, "MM/dd/yyyy"));
                            }
                            catch (NoSuchElementException e)
                            {
                                logger.Error("No such element - END OF TENDERING date picker was not found: " + e.Message);
                            }

                        }
                    }

                }

                //Set time to be at HH:30 if less than 20 minutes have passed after new hour
                if (timeCurrentMM1 <= 20)
                {

                    time1HourFromCurrentTime = incrementYYmmDDhhMMssBy2(0, 0, 0, 0, (30 - timeCurrentMM1), 0, "hh:mm tt");
                    Console.WriteLine("Time set to be at HH:30 as less than 20 minutes have passed after new hour: " + time1HourFromCurrentTime);

                    //Rounding minutes to 30 or 00
                    time1HourFromCurrentTime = roundingMinutes(time1HourFromCurrentTime);

                }

                //Set time to the next hour if more than 20 minutes have already passed after the new hour but still more than 10 minutes remaining till the next hour
                if (timeCurrentMM1 > 20 && timeCurrentMM1 < 49)
                {

                    time1HourFromCurrentTime = incrementYYmmDDhhMMssBy2(0, 0, 0, 0, (60 - timeCurrentMM1), 0, "hh:mm tt");
                    Console.WriteLine("Time set to the next hour as more than 20 minutes have already passed after the new hour but still more than 10 minutes remaining till the next hour: " + time1HourFromCurrentTime);

                    //Rounding minutes to 30 or 00
                    time1HourFromCurrentTime = roundingMinutes(time1HourFromCurrentTime);

                    //Change "End of Tendering" date to the next day on the border of two days
                    if (timeCurrentTime.Substring(timeCurrentTime.Length - 2).Equals("PM"))
                    {

                        if (timeCurrentTime.Substring(timeCurrentTime.Length - timeCurrentTime.Length, 2).Equals("11"))
                        {

                            //Providing current date in the "End of tendering" calendar
                            try
                            {
                                endDate.Clear();
                                endDate.SendKeys(incrementYYmmDDhhMMssBy1(0, 0, 1, 0, 0, 0, "MM/dd/yyyy"));
                            }
                            catch (NoSuchElementException e)
                            {
                                logger.Error("No such element - END OF TENDERING date picker was not found: " + e.Message);
                            }

                        }
                    }

                }



                //Change the time's AM/PM letters to lower case as they appear to be in the system
                String finalEndOfTenderingTimeLowerCase = time1HourFromCurrentTime.ToLowerInvariant();
                Console.WriteLine("END OF TENDERING time set to lower case: " + finalEndOfTenderingTimeLowerCase);


                if (finalEndOfTenderingTimeLowerCase.Substring(0, 1).Equals("0"))
                {

                    finalEndOfTenderingTimeLowerCase = finalEndOfTenderingTimeLowerCase.Substring(1);
                    Console.WriteLine("Trimmed finalEndOfTenderingTimeLowerCase: " + finalEndOfTenderingTimeLowerCase);

                }


                tenderEndTime = finalEndOfTenderingTimeLowerCase;

                //Click on the time picker field for "End of Tendering" date
                executor.ExecuteScript("arguments[0].click();", endTime);

                System.Threading.Thread.Sleep(1000);


                //Find the required time from the time picker dropdown and select it (for "End of Tendering" date)
                try
                {
                    IList<IWebElement> available_times = driver.FindElements(By.XPath("//*[@class='x-boundlist-list-ct']/ul/descendant::*"));

                    foreach (IWebElement item in available_times)
                    {

                        if (item.Text.Equals(time1HourFromCurrentTime) || item.Text.Equals(finalEndOfTenderingTimeLowerCase))
                        {

                            //Select and click on calculated "End of Tendering" time
                            IWebElement el = driver.FindElement(By.XPath("//*[@class='x-boundlist-list-ct']/ul/descendant::li[text() = '" + item.Text + "']"));

                            executor.ExecuteScript("arguments[0].click();", el);
                            //driver.findElement(By.linkText(finalEndOfTenderingTimeLowerCase)).sendKeys(Keys.ENTER);

                            System.Threading.Thread.Sleep(1000);

                            break;
                            //return;
                        }
                    }
                }
                catch (Exception e)
                {
                    logger.Error("Unable to select time for END OF TENDERING time picker: " + e.Message);
                }


            }
            else
            { //if current time is not AM/PM format

                logger.Info("24 HOURS TIME FORMAT DETECTED in the time picker: " + timeX);

                //Simply set the "Start of Tendering" date to yesterday
                try
                {
                    driver.FindElement(By.XPath("//input[@id='StartTenderDate-inputEl']")).Clear();
                    driver.FindElement(By.XPath("//input[@id='StartTenderDate-inputEl']")).SendKeys(incrementYYmmDDhhMMssBy1(0, 0, -1, 0, 0, 0, "dd/MM/yyyy"));
                }
                catch (NoSuchElementException e)
                {
                    logger.Error("No such element - START OF TENDERING date picker was not found: " + e.Message);
                }

                //Providing current date in the "End of tendering" calendar
                try
                {
                    driver.FindElement(By.XPath("//input[@id='EndTenderDate-inputEl']")).Clear();
                    driver.FindElement(By.XPath("//input[@id='EndTenderDate-inputEl']")).SendKeys(incrementYYmmDDhhMMssBy1(0, 0, 0, 0, 0, 0, "dd/MM/yyyy"));
                }
                catch (NoSuchElementException e)
                {
                    logger.Error("No such element - END OF TENDERING date picker was not found: " + e.Message);
                }


                //Provide "Start of collaboration" date which is 7 days later from now
                try
                {
                    driver.FindElement(By.XPath("//input[@id='StartCollaboration-inputEl']")).Clear();
                    driver.FindElement(By.XPath("//input[@id='StartCollaboration-inputEl']")).SendKeys(incrementYYmmDDhhMMssBy1(0, 0, 7, 0, 0, 0, "dd/MM/yyyy"));
                }
                catch (NoSuchElementException e)
                {
                    logger.Error("No such element - START OF COLLABORATION date picker was not found: " + e.Message);
                }


                //Provide "End of collaboration" date which is 37 days later from now
                try
                {
                    driver.FindElement(By.XPath("//input[@id='FinishCollaboration-inputEl']")).Clear();
                    driver.FindElement(By.XPath("//input[@id='FinishCollaboration-inputEl']")).SendKeys(incrementYYmmDDhhMMssBy1(0, 0, 27, 0, 0, 0, "dd/MM/yyyy"));
                }
                catch (NoSuchElementException e)
                {
                    logger.Error("No such element - END OF COLLABORATION date picker was not found: " + e.Message);
                }

                //Retrieve, process and insert correct time into the END OF TENDERING time picker


                //Get current time in 24H format to string
                String timeCurrentTime = incrementYYmmDDhhMMssBy3(0, 0, 0, 0, 0, 0, "H:mm");
                Console.WriteLine("Current time: " + timeCurrentTime);

                //Initialize empty string variable
                String time1HourFromCurrentTime = "";


                //Getting to string the minutes of the current time
                String timeCurrentMM = timeCurrentTime.Substring(timeCurrentTime.Length - 5, 2);
                Console.WriteLine("Current minutes: " + timeCurrentMM);
                int timeCurrentMM1 = Int32.Parse(timeCurrentMM);


                //After 45 minutes
                if (timeCurrentMM1 >= 50)
                {

                    //Set time to be 30 + XX minutes from now if less than 10 minutes remaining till the next hour
                    time1HourFromCurrentTime = incrementYYmmDDhhMMssBy3(0, 0, 0, 0, (30 + (60 - timeCurrentMM1)), 0, "H:mm");
                    Console.WriteLine("Time set to be 30 + XX minutes from now as less than 10 minutes remaining till the next hour: " + time1HourFromCurrentTime);

                    //Rounding minutes to 30 or 00
                    time1HourFromCurrentTime = roundingMinutes(time1HourFromCurrentTime);

                    //Change "End of Tendering" date to the next day on the border of two days
                    if (Int32.Parse(timeCurrentTime.Substring(timeCurrentTime.Length - 5, 2)) == 23)
                    {

                        //Providing current date in the "End of tendering" calendar
                        try
                        {
                            driver.FindElement(By.XPath("//input[@id='EndTenderDate-inputEl']")).Clear();
                            driver.FindElement(By.XPath("//input[@id='EndTenderDate-inputEl']")).SendKeys(incrementYYmmDDhhMMssBy1(0, 0, 1, 0, 0, 0, "MM/dd/yyyy"));
                        }
                        catch (NoSuchElementException e)
                        {
                            logger.Error("No such element - END OF TENDERING date picker was not found: " + e.Message);
                        }

                    }
                }

                //Set time to be at HH:30 if less than 20 minutes have passed after new hour
                if (timeCurrentMM1 <= 20)
                {

                    time1HourFromCurrentTime = incrementYYmmDDhhMMssBy3(0, 0, 0, 0, -timeCurrentMM1 + 30, 0, "H:mm");
                    Console.WriteLine("Time set to be at HH:30 as less than 20 minutes have passed after new hour: " + time1HourFromCurrentTime);

                    //Rounding minutes to 30 or 00
                    time1HourFromCurrentTime = roundingMinutes(time1HourFromCurrentTime);
                }

                //Set time to the next hour if more than 20 minutes have already passed after the new hour but still more than 10 minutes remaining till the next hour
                if (timeCurrentMM1 > 20 && timeCurrentMM1 < 49)
                {

                    time1HourFromCurrentTime = incrementYYmmDDhhMMssBy3(0, 0, 0, 0, (60 - timeCurrentMM1), 0, "H:mm");
                    Console.WriteLine("Time set to the next hour as more than 20 minutes have already passed after the new hour but still more than 10 minutes remaining till the next hour: " + time1HourFromCurrentTime);

                    //Rounding minutes to 30 or 00
                    time1HourFromCurrentTime = roundingMinutes(time1HourFromCurrentTime);

                    //Change "End of Tendering" date to the next day on the border of two days
                    if (timeCurrentTime.Substring(timeCurrentTime.Length - timeCurrentTime.Length, timeCurrentTime.Length - (timeCurrentTime.Length - 2)).Equals("23"))
                    {

                        //Providing current date in the "End of tendering" calendar
                        try
                        {
                            driver.FindElement(By.XPath("//input[@id='EndTenderDate-inputEl']")).Clear();
                            driver.FindElement(By.XPath("//input[@id='EndTenderDate-inputEl']")).SendKeys(incrementYYmmDDhhMMssBy1(0, 0, 1, 0, 0, 0, "MM/dd/yyyy"));
                        }
                        catch (NoSuchElementException e)
                        {
                            logger.Error("No such element - END OF TENDERING date picker was not found: " + e.Message);
                        }
                    }

                }



                if (time1HourFromCurrentTime.Substring(0, 1).Equals("0"))
                {

                    time1HourFromCurrentTime = time1HourFromCurrentTime.Substring(1);
                    Console.WriteLine("Trimmed finalEndOfTenderingTimeLowerCase: " + time1HourFromCurrentTime);

                }


                tenderEndTime = time1HourFromCurrentTime;

                //Click on the time picker field for "End of Tendering" date
                executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//*[@id='EndTenderTime-inputEl']")));

                System.Threading.Thread.Sleep(1000);


                //Find the required time from the time picker dropdown and select it (for "End of Tendering" date)
                try
                {
                    IList<IWebElement> available_times = driver.FindElements(By.XPath("//*[@class='x-boundlist-list-ct']/ul/descendant::*"));

                    foreach (IWebElement item in available_times)
                    {

                        if (item.Text.Equals(time1HourFromCurrentTime))
                        {

                            //Select and click on calculated "End of Tendering" time
                            IWebElement el = driver.FindElement(By.XPath("//*[@class='x-boundlist-list-ct']/ul/descendant::li[text() = '" + item.Text + "']"));

                            executor.ExecuteScript("arguments[0].click();", el);

                            System.Threading.Thread.Sleep(1000);

                            break;
                        }
                    }

                }
                catch (Exception e)
                {
                    logger.Error("Unable to select time for END OF TENDERING time picker: " + e.Message);
                }

            }


            IList<IWebElement> comboItems;
            var awarding = driver.FindElement(By.XPath("//*[@id='AwardCombo-inputEl']"));
            executor.ExecuteScript("arguments[0].click();", awarding);
            //awarding.Click();
            comboItems = driver.FindElements(By.ClassName("x-boundlist-item"));
            var c1 = comboItems.First(item => item.Text.Trim() == CreateTenderModel.Awarding_Step1);
            executor.ExecuteScript("arguments[0].click();", c1);
            //comboItems.First(item => item.Text.Trim() == CreateTenderModel.Awarding_Step1).Click();

            //startCollaborationitle.SendKeys(startDate.GetAttribute("value"));
            System.Threading.Thread.Sleep(100);

            //finishCollaboration.SendKeys(startDate.GetAttribute("value"));
            //System.Threading.Thread.Sleep(100);

            var target = driver.FindElement(By.XPath("//*[@id='ReasonCombo-inputEl']"));
            executor.ExecuteScript("arguments[0].click();", target);
            //target.Click();
            comboItems = driver.FindElements(By.ClassName("x-boundlist-item"));
            var c2 = comboItems.First(item => item.Text.Trim() == CreateTenderModel.TargerForTendering_Step1);
            executor.ExecuteScript("arguments[0].click();", c2);
            //comboItems.First(item => item.Text.Trim() == CreateTenderModel.TargerForTendering_Step1).Click();

            System.Threading.Thread.Sleep(1000);
            var next = driver.FindElement(By.XPath("//*[contains(text(), 'Next')]"));
            executor.ExecuteScript("arguments[0].click();", next);
            //next.Click();
        }
        private void CreateTenderProcessStep2()
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

            var title = driver.FindElement(By.XPath("//*[@id='tenderWizardDlg_header_hd-textEl']"));
            Assert.IsTrue(title.Text.Contains("Starting new tender - Tender settings"));
            //Assert.AreEqual(title.Text, string.Format("Starting new tender - Tender settings - Step 2/9 ({0})", CreateTenderModel.TenderTiltle_Step1));

            setCurrencies();


            //Click to select "Allow carriers to provide additional comments together with bids" check-box
            executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//input[@id='UseUploadComments-inputEl']")));

            System.Threading.Thread.Sleep(1000);



            var next = driver.FindElement(By.XPath("//*[contains(text(), 'Next')]"));
            executor.ExecuteScript("arguments[0].click();", next);

        }




        private void CreateTenderProcessStep3()
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

            var title = driver.FindElement(By.XPath("//*[@id='tenderWizardDlg_header_hd-textEl']"));
            Assert.IsTrue(title.Text.Contains("Starting new tender - Freight"));
            //Assert.AreEqual(title.Text, string.Format("Starting new tender - Freight - Step 3/9 ({0})", CreateTenderModel.TenderTiltle_Step1));

            var freightHeadline = driver.FindElement(By.XPath("//*[@id='Destination-inputEl']"));
            freightHeadline.SendKeys(CreateTenderModel.FreightHeadline_Step3);

            var next = driver.FindElement(By.XPath("//*[contains(text(), 'Next')]"));
            executor.ExecuteScript("arguments[0].click();", next);
        }

        private void CreateTenderProcessStep4()
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

            var title = driver.FindElement(By.XPath("//*[@id='tenderWizardDlg_header_hd-textEl']"));
            Assert.IsTrue(title.Text.Contains("Starting new tender - Transport"));
            //Assert.AreEqual(title.Text, string.Format("Starting new tender - Transport - Step 4/9 ({0})", CreateTenderModel.TenderTiltle_Step1));

            var roadCheckbox = driver.FindElement(By.XPath("//*[contains(text(), 'Road transport is requested during this tender')]/preceding-sibling::input"));
            executor.ExecuteScript("arguments[0].click();", roadCheckbox);

            /*
                        //Check if the "Road transport is requested during this tender" check-box is enabled
                        if (driver.FindElement(By.XPath("//div[@id='RoadPanel-body']/table[@class='x-field x-form-item x-field-default x-autocontainer-form-item']/tbody/tr/td[@class='x-form-item-body x-form-cb-wrap']/input[@class='x-form-field x-form-checkbox']")).Enabled)
                        {

                            //Click on the "Road transport is requested during this tender" check-box
                            executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//div[@id='RoadPanel-body']/table[@class='x-field x-form-item x-field-default x-autocontainer-form-item']/tbody/tr/td[@class='x-form-item-body x-form-cb-wrap']/input[@class='x-form-field x-form-checkbox']")));

                            System.Threading.Thread.Sleep(500);

                        }
                        else
                        {
                            logger.Error("ROAD TRANSPORT IS REQUESTED DURING THIS TENDER check-box on STEP# 4 - TRANSPORT - ROAD tab is DISABLED.");

                        }*/


            //Selecting all possible options in the "Transport description and specifications" section on the Step4-Transports-Road tab
            try
            {

                //Check if the "Subcontractors are allowed for this tender" check-box is enabled
                if (driver.FindElement(By.XPath("//div[@id='RoadPanel-body']/fieldset/div/table/tbody/tr/td[@class='x-form-item-body x-form-cb-wrap']/input[@class='x-form-field x-form-checkbox']")).Enabled)
                {

                    //Click on the "Subcontractors are allowed for this tender" check-box
                    executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//div[@id='RoadPanel-body']/fieldset/div/table/tbody/tr/td[@class='x-form-item-body x-form-cb-wrap']/input[@class='x-form-field x-form-checkbox']")));

                    System.Threading.Thread.Sleep(500);


                    //Click on the "Service sector" to select all dropdown items
                    executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//table[@id='ServiceSectorCombo-triggerWrap']/tbody/tr/td[@class='x-trigger-cell']/div[@class='x-trigger-index-0 x-form-trigger x-form-simpletick-trigger x-unselectable']")));
                    System.Threading.Thread.Sleep(500);


                    //Click on "Average Truck age" dropdown and select a value
                    try
                    {

                        executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//*[@id='TruckAgeCombo-inputEl']")));

                        System.Threading.Thread.Sleep(500);

                        IWebElement el = driver.FindElement(By.XPath("//div[@class='x-boundlist-list-ct']/ul/descendant::li[text() = '" + "< 4 years" + "']"));
                        executor.ExecuteScript("arguments[0].click();", el);

                        System.Threading.Thread.Sleep(500);

                    }
                    catch (Exception e)
                    {
                        logger.Error("Unable to click on the AVERAGE TRUCK AGE droplist on STEP# 4 - TRANSPORT - ROAD tab: " + e.Message);
                    }


                    //Click on the "Truck Type" to select all droipdown items
                    executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//table[@id='TruckTypeCombo-triggerWrap']/tbody/tr/td[@class='x-trigger-cell']/div[@class='x-trigger-index-0 x-form-trigger x-form-simpletick-trigger x-unselectable']")));
                    System.Threading.Thread.Sleep(500);


                    //Click on the "Truck Type Mounting" to select all droipdown items
                    executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//table[@id='TruckSpecificationCombo-triggerWrap']/tbody/tr/td[@class='x-trigger-cell']/div[@class='x-trigger-index-0 x-form-trigger x-form-simpletick-trigger x-unselectable']")));
                    System.Threading.Thread.Sleep(500);


                    //Click on the "Exhaust Standard" to select all droipdown items
                    executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//table[@id='TruckExhaustStandardCombo-triggerWrap']/tbody/tr/td[@class='x-trigger-cell']/div[@class='x-trigger-index-0 x-form-trigger x-form-simpletick-trigger x-unselectable']")));
                    System.Threading.Thread.Sleep(500);


                    //Click on "Own Fleet %" dropdown and select a value
                    try
                    {

                        executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//input[@name='OwnFleet']")));

                        System.Threading.Thread.Sleep(500);

                        IWebElement el = driver.FindElement(By.XPath("//div[@class='x-boundlist-list-ct']/ul/descendant::li[text() = '" + "40%" + "']"));
                        executor.ExecuteScript("arguments[0].click();", el);

                        System.Threading.Thread.Sleep(500);

                    }
                    catch (Exception e)
                    {
                        logger.Error("Unable to click on the OWN FLEET % droplist on STEP# 4 - TRANSPORT - ROAD tab: " + e.Message);
                    }


                    //Click on the "Truck Type Mounting - Additional Information" to select all droipdown items
                    executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//table[@id='TruckAdditionalCombo-triggerWrap']/tbody/tr/td[@class='x-trigger-cell']/div[@class='x-trigger-index-0 x-form-trigger x-form-simpletick-trigger x-unselectable']")));
                    System.Threading.Thread.Sleep(500);


                    //Click on the "Truck Equipment" to select all droipdown items
                    executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//table[@id='TruckEquipmentCombo-triggerWrap']/tbody/tr/td[@class='x-trigger-cell']/div[@class='x-trigger-index-0 x-form-trigger x-form-simpletick-trigger x-unselectable']")));
                    System.Threading.Thread.Sleep(500);


                }
                else
                {
                    logger.Error("SUBCONTRACTORS ARE ALLOWED FOR THIS TENDER check-box on STEP# 4 - TRANSPORT - ROAD tab is DISABLED.");
                    driver.Quit();
                }


            }
            catch (Exception e)
            {
                logger.Error("Error while selecting options on STEP4_TRANSPORT_ROAD tab: " + e.Message);
            }


            var next = driver.FindElement(By.XPath("//*[contains(text(), 'Next')]"));
            executor.ExecuteScript("arguments[0].click();", next);
        }
        private void CreateTenderProcessStep5()
        {
            Thread.Sleep(7000);

            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

            var title = driver.FindElement(By.XPath("//*[@id='tenderWizardDlg_header_hd-textEl']"));
            Assert.IsTrue(title.Text.Contains("Starting new tender - Bidding matrix"));
            //Assert.AreEqual(title.Text, string.Format("Starting new tender - Bidding matrix - Step 5/9 ({0})", CreateTenderModel.TenderTiltle_Step1));

            executor.ExecuteScript("objShippingMatrix.Content.ShippingMatrixClient.ImportTestMatrix('D:/ccx3/Storage/Default.ccx');");
            Thread.Sleep(7000);

            executor.ExecuteScript("objShippingMatrix.Content.ShippingMatrixClient.SaveMatrix();");
            Thread.Sleep(7000);

            var next = driver.FindElement(By.XPath("//*[contains(text(), 'Next')]"));
            executor.ExecuteScript("arguments[0].click();", next);
        }
        private void CreateTenderProcessStep6()
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

            var title = driver.FindElement(By.XPath("//*[@id='tenderWizardDlg_header_hd-textEl']"));
            Assert.IsTrue(title.Text.Contains("Starting new tender - Service providers"));
            //Assert.AreEqual(title.Text, string.Format("Starting new tender - Service providers - Step 6/9 ({0})", CreateTenderModel.TenderTiltle_Step1));

            var formPanel = driver.FindElement(By.XPath("//*[@id='SubmitFormPanel-body']"));
            var btn = formPanel.FindElements(By.TagName("table"))[5].FindElements(By.TagName("tr"))[1].FindElements(By.TagName("td"))[0].FindElements(By.TagName("button"))[0];

            executor.ExecuteScript("arguments[0].click();", btn);
            System.Threading.Thread.Sleep(5000);

            var next = driver.FindElement(By.XPath("//*[contains(text(), 'Next')]"));
            executor.ExecuteScript("arguments[0].click();", next);
        }

        private void CreateTenderProcessStep7()
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

            var title = driver.FindElement(By.XPath("//*[@id='tenderWizardDlg_header_hd-textEl']"));
            Assert.IsTrue(title.Text.Contains("Starting new tender - Notifications"));
            //Assert.AreEqual(title.Text, string.Format("Starting new tender - Notifications - Step 7/9 ({0})", CreateTenderModel.TenderTiltle_Step1));

            var ok = driver.FindElement(By.XPath("//*[contains(text(), 'OK')]"));
            executor.ExecuteScript("arguments[0].click();", ok);

            var next = driver.FindElement(By.XPath("//*[contains(text(), 'Next')]"));
            executor.ExecuteScript("arguments[0].click();", next);
        }
        private void CreateTenderProcessStep8()
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

            var title = driver.FindElement(By.XPath("//*[@id='tenderWizardDlg_header_hd-textEl']"));
            Assert.IsTrue(title.Text.Contains("Starting new tender - Preconditions"));
            //Assert.AreEqual(title.Text, string.Format("Starting new tender - Preconditions - Step 8/9 ({0})", CreateTenderModel.TenderTiltle_Step1));

            var privacyStatmentCheckbox = driver.FindElement(By.XPath("//*[@id='PrivacyStatmentFieldSet-legendChk-inputEl']"));
            executor.ExecuteScript("arguments[0].click();", privacyStatmentCheckbox);

            var next = driver.FindElement(By.XPath("//*[contains(text(), 'Next')]"));
            executor.ExecuteScript("arguments[0].click();", next);
        }
        private void CreateTenderProcessStep9()
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

            var title = driver.FindElement(By.XPath("//*[@id='tenderWizardDlg_header_hd-textEl']"));
            Assert.IsTrue(title.Text.Contains("Starting new tender - Finish"));
            //Assert.AreEqual(title.Text, string.Format("Starting new tender - Finish - Step 9/9 ({0})", CreateTenderModel.TenderTiltle_Step1));

            var publishBtn = driver.FindElement(By.XPath("//*[@id='Publish-btnEl']"));
            executor.ExecuteScript("arguments[0].click();", publishBtn);
            System.Threading.Thread.Sleep(3000);

            var acceptCheckbox = driver.FindElement(By.XPath("//*[@id='AcceptCheckboxBox-inputEl']"));
            executor.ExecuteScript("arguments[0].click();", acceptCheckbox);

            var saveBtn = driver.FindElement(By.XPath("//*[@id='SaveBtn-btnEl']"));
            executor.ExecuteScript("arguments[0].click();", saveBtn);
            System.Threading.Thread.Sleep(3000);

            var ok = driver.FindElement(By.XPath("//*[contains(text(), 'OK')]"));
            executor.ExecuteScript("arguments[0].click();", ok);
        }

        private void SetUpLogInTestSettings()
        {
            BuildShipperUser("s03", "admin");
        }
        private void SetUpVerifyScreensTestSettings()
        {
            BuildShipperUser("s03", "admin");

        }
        private void SetUpCreateTenderTestSettings()
        {
           // BuildShipperUser("s03", "admin");

            String stringDate = incrementYYmmDDhhMMssBy1(0, 0, 0, 0, 0, 0, "MMM/dd/yyy HH:mm:ss");

            CreateTenderModel = new TenderModel()
            {
                TenderTiltle_Step1 = "TEST_AUTOMATION_Tender_C#_Created_on_" + stringDate,
                TenderNumber_Step1 = "TestTenderNumber",
                InternalMemo_Step1 = "TestTenderInternalMemo",
                TenderDescription_Step1 = "TestTenderDescription",
                TargerForTendering_Step1 = "New business",
                Awarding_Step1 = "Award to a service provider",
                FreightHeadline_Step3 = "Freight Headline",
                FreightDescription_Step3 = "Freight Description"
            };
        }


        private String incrementYYmmDDhhMMssBy1(int year, int month, int date, int hour, int minute, int second, String simpDateFormat)
        {
            DateTime currentDate = DateTime.Now;
            String dateToString = "";

            DateTime answer = currentDate.AddDays(year);
            answer = answer.AddMonths(month);
            answer = answer.AddDays(date);
            answer = answer.AddMinutes(minute);
            answer = answer.AddSeconds(second);

            dateToString = answer.ToString(simpDateFormat);

            return dateToString;
        }



        private String incrementYYmmDDhhMMssBy2(int year, int month, int date, int hour, int minute, int second, String simpDateFormat)
        {
            String dateToString = "";

            try
            {

                // convert date to calendar
                DateTime oDate = Convert.ToDateTime(getCurrentTimeFromShippersDashboardAndConvert24Hto12H());

                DateTime answer = oDate.AddDays(year);
                answer = answer.AddMonths(month);
                answer = answer.AddDays(date);
                answer = answer.AddMinutes(minute);
                answer = answer.AddSeconds(second);

                dateToString = answer.ToString(simpDateFormat);

            }
            catch (Exception e)
            {
                logger.Error("Unable to increment year, month, date, hour, minute or second in 'incrementYYmmDDhhMMssBy_1' method: " + e.Message);
            }

            return dateToString;
        }



        private String incrementYYmmDDhhMMssBy3(int year, int month, int date, int hour, int minute, int second, String simpDateFormat)
        {
            String dateToString = "";

            try
            {

                // convert date to calendar
                DateTime oDate = Convert.ToDateTime(getCurrentTimeFromShippersDashboardIn24Hformat());

                DateTime answer = oDate.AddDays(year);
                answer = answer.AddMonths(month);
                answer = answer.AddDays(date);
                answer = answer.AddMinutes(minute);
                answer = answer.AddSeconds(second);

                dateToString = answer.ToString(simpDateFormat);


                //Get to string 2 first digits (HH) of current time
                String dateToString1 = dateToString.Substring(dateToString.Length - 8, 2);


                if (dateToString1 == "24")
                {

                    dateToString1 = "00";
                    dateToString = dateToString.Replace(dateToString.Substring(dateToString.Length - 5, 2), dateToString1);

                }

            }
            catch (Exception e)
            {
                logger.Error("Unable to increment year, month, date, hour, minute or second in 'incrementYYmmDDhhMMssBy_1' method: " + e.Message);
            }
            return dateToString;

        }




        private String getCurrentTimeFromShippersDashboardAndConvert24Hto12H()
        {

            String dashboardCurrentTime = "";

            //Getting date and time from the shipper's dashboard
            try
            {
                dashboardCurrentTime = driver.FindElement(By.XPath("//*[@id='appCurDateTime']/.//span[contains(@class,'x-label-value')]")).Text;
                Console.WriteLine("Current DASHBOARD date/time: " + dashboardCurrentTime);
            }
            catch (NoSuchElementException e)
            {
                logger.Error("No such element - SHIPPER's TIMER on DASHBOARD was not found: " + e.Message);
            }


            //Getting to string the time value only (out of date, month, year and time)
            dashboardCurrentTime = dashboardCurrentTime.Substring(dashboardCurrentTime.Length - 5);
            Console.WriteLine("Current DASHBOARD TIME: " + dashboardCurrentTime);


            //Replace space with "0" at the beginning if hours are not a 2 digit number
            if (dashboardCurrentTime.Substring(0, 1).Equals(" "))
            {

                dashboardCurrentTime = dashboardCurrentTime.Replace(dashboardCurrentTime.Substring(0, 1), "0");
                Console.WriteLine("Trimmed time from shipper's Dashboard: " + dashboardCurrentTime);

            }

            //Convert 24H format to 12H format
            String convertedTimeFormat = "";

            try
            {
                DateTime dateValue = DateTime.Parse(dashboardCurrentTime, null, DateTimeStyles.None);
                Console.WriteLine("'{0}' converted to {1}.", dashboardCurrentTime, dateValue);
                convertedTimeFormat = dateValue.ToString("hh:mm tt");
            }
            catch (FormatException)
            {
                Console.WriteLine("Unable to convert 24H format to 12H format. ", convertedTimeFormat);
            }

            //String convertedTimeFormat = LocalTime.parse(dashboardCurrentTime, DateTimeFormatter.ofPattern("H:mm")).format(DateTimeFormatter.ofPattern("hh:mm a"));
            Console.WriteLine("Converted time from 24H to 12H: " + convertedTimeFormat);

            return convertedTimeFormat;
        }




        private String getCurrentTimeFromShippersDashboardIn24Hformat()
        {

            String dashboardCurrentTime = "";

            //Getting date and time from the shipper's dashboard
            try
            {
                dashboardCurrentTime = driver.FindElement(By.XPath("//*[@id='appCurDateTime']/.//span[contains(@class,'x-label-value')]")).Text;
                Console.WriteLine("Current DASHBOARD date/time: " + dashboardCurrentTime);
            }
            catch (NoSuchElementException e)
            {
                logger.Error("No such element - SHIPPER's TIMER on DASHBOARD was not found: " + e.Message);
            }


            //Getting to string the time value only (out of date, month, year and time)
            dashboardCurrentTime = dashboardCurrentTime.Substring(dashboardCurrentTime.Length - 5);
            Console.WriteLine("Current DASHBOARD TIME: " + dashboardCurrentTime);


            if (dashboardCurrentTime.Substring(0, 1).Equals(" "))
            {

                dashboardCurrentTime = dashboardCurrentTime.Replace(dashboardCurrentTime.Substring(0, 1), "0");
                Console.WriteLine("Trimmed time from shipper's Dashboard: " + dashboardCurrentTime);

            }
            return dashboardCurrentTime;
        }



        private String roundingMinutes(String currentTime)
        {
            String rounded_time1HourFromCurrentTime_minutes = currentTime.Substring(currentTime.Length - 5, 2);
            Console.WriteLine("roundingMinutes method minutes: " + rounded_time1HourFromCurrentTime_minutes);

            //Round current minutes to an integer in 30 increments (half an hour)
            int roundedCurrentMM = ((Convert.ToInt32(rounded_time1HourFromCurrentTime_minutes) + 29) / 30) * 30;


            //Convert minutes to 2-digit number (e.g. "7" to "07")
            String roundedCurrentMM1 = roundedCurrentMM.ToString("00");


            //Insert rounded minutes into a time variable
            currentTime = currentTime.Replace(rounded_time1HourFromCurrentTime_minutes, roundedCurrentMM1);

            return currentTime;
        }

        private void setCurrencies()
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

            //Check if the "Add Currency" button is enabled and add 6 more currencies (i.e USD, GBP, SEK, CHF, NOK, RUB)
            if (driver.FindElement(By.XPath("//*[@id='btnAddCurrency-btnEl']")).Enabled)
            {
                int i = 0;
                try
                {
                    while (i < 6)
                    {

                        //Click on the "Add Currency" button
                        executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//*[@id='btnAddCurrency-btnEl']")));
                        System.Threading.Thread.Sleep(500);

                        //Click on "Update" button
                        driver.FindElement(By.XPath("//*[@id='CurrenciesCombo-inputEl']")).SendKeys(Keys.Enter);

                        //Next currency
                        i++;
                    }
                }
                catch (NoSuchElementException e)
                {
                    logger.Error("No such element - ADD CURRENCY button was not found: " + e.Message);
                }
            }
            else
            {

                logger.Error("ADD CURRENCY button is DISABLED on STEP2_TENDER_SETTINGS form.");

            }


            //Set currency symbols
            try
            {

                IList<IWebElement> available_CurrencyRows = driver.FindElements(By.XPath("//div[@id='CurrenciesGridPanel-body']/div/table[@class='x-grid-table x-grid-table-resizer']/tbody/descendant::tr"));

                int RowIndex = 1;

                //Loop the table's rows
                foreach (IWebElement item in available_CurrencyRows)
                {

                    //Retrieve all columns from the row
                    IList<IWebElement> TotalColumnCount = item.FindElements(By.XPath("td"));

                    int ColumnIndex = 1;

                    //Loop the columns of a row
                    foreach (IWebElement colElement in TotalColumnCount)
                    {

                        //Read each cell's text
                        String optionText = colElement.Text;
                        //Console.WriteLine ("TR_TEXT: " + optionText);

                        switch (optionText)
                        {
                            case "NOK":

                                //Double-click on a row to open it for editing
                                new Actions(driver).DoubleClick(driver.FindElement(By.XPath("//div[@id='CurrenciesGridPanel-body']/div/table/tbody/tr/td/div[contains(text(), 'NOK')]"))).Perform();


                                //Insert "&" symbol for NOK currency
                                driver.FindElement(By.XPath("//div[@id='CurrenciesGridPanel-body']/div/div/div/div/div/table[@id='TextField2']/tbody/tr/td[@id='TextField2-bodyEl']/input[@id='TextField2-inputEl']")).SendKeys("&");

                                //Insert NOK currency exchange rate as "9.5620"
                                //click on the "Rate" field
                                executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//div[@id='CurrenciesGridPanel-body']/div/div/div/div/div/table[@id='NumberField1']/tbody/tr/td[@id='NumberField1-bodyEl']/table[@id='NumberField1-triggerWrap']/tbody/tr/td[@id='NumberField1-inputCell']/input[@id='NumberField1-inputEl']")));
                                System.Threading.Thread.Sleep(500);

                                //remove existing rate value from the "Rate" field
                                driver.FindElement(By.XPath("//div[@id='CurrenciesGridPanel-body']/div/div/div/div/div/table[@id='NumberField1']/tbody/tr/td[@id='NumberField1-bodyEl']/table[@id='NumberField1-triggerWrap']/tbody/tr/td[@id='NumberField1-inputCell']/input[@id='NumberField1-inputEl']")).Clear();

                                //Insert NOK currency exchange rate as "9.5620"
                                driver.FindElement(By.XPath("//div[@id='CurrenciesGridPanel-body']/div/div/div/div/div/table[@id='NumberField1']/tbody/tr/td[@id='NumberField1-bodyEl']/table[@id='NumberField1-triggerWrap']/tbody/tr/td[@id='NumberField1-inputCell']/input[@id='NumberField1-inputEl']")).SendKeys("9.5620");

                                //Click on "Update" button
                                driver.FindElement(By.XPath("//*[@id='CurrenciesCombo-inputEl']")).SendKeys(Keys.Enter);
                                break;

                            case "SEK":

                                //Double-click on a row to open it for editing
                                new Actions(driver).DoubleClick(driver.FindElement(By.XPath("//div[@id='CurrenciesGridPanel-body']/div/table/tbody/tr/td/div[contains(text(), 'SEK')]"))).Perform();

                                //Insert "*" symbol for SEK currency
                                driver.FindElement(By.XPath("//div[@id='CurrenciesGridPanel-body']/div/div/div/div/div/table[@id='TextField2']/tbody/tr/td[@id='TextField2-bodyEl']/input[@id='TextField2-inputEl']")).SendKeys("*");

                                //Insert SEK currency exchange rate as "9.7645"
                                //click on the "Rate" field
                                executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//div[@id='CurrenciesGridPanel-body']/div/div/div/div/div/table[@id='NumberField1']/tbody/tr/td[@id='NumberField1-bodyEl']/table[@id='NumberField1-triggerWrap']/tbody/tr/td[@id='NumberField1-inputCell']/input[@id='NumberField1-inputEl']")));
                                System.Threading.Thread.Sleep(500);

                                //remove existing rate value from the "Rate" field
                                driver.FindElement(By.XPath("//div[@id='CurrenciesGridPanel-body']/div/div/div/div/div/table[@id='NumberField1']/tbody/tr/td[@id='NumberField1-bodyEl']/table[@id='NumberField1-triggerWrap']/tbody/tr/td[@id='NumberField1-inputCell']/input[@id='NumberField1-inputEl']")).Clear();

                                //Insert NOK currency exchange rate as "9.7645"
                                driver.FindElement(By.XPath("//div[@id='CurrenciesGridPanel-body']/div/div/div/div/div/table[@id='NumberField1']/tbody/tr/td[@id='NumberField1-bodyEl']/table[@id='NumberField1-triggerWrap']/tbody/tr/td[@id='NumberField1-inputCell']/input[@id='NumberField1-inputEl']")).SendKeys("9.7645");
                                
                                //Click on "Update" button
                                driver.FindElement(By.XPath("//*[@id='CurrenciesCombo-inputEl']")).SendKeys(Keys.Enter);
                                break;

                            case "CHF":
                                //Double-click on a row to open it for editing
                                new Actions(driver).DoubleClick(driver.FindElement(By.XPath("//div[@id='CurrenciesGridPanel-body']/div/table/tbody/tr/td/div[contains(text(), 'CHF')]"))).Perform();

                                //Insert "#" symbol for CHF currency
                                driver.FindElement(By.XPath("//div[@id='CurrenciesGridPanel-body']/div/div/div/div/div/table[@id='TextField2']/tbody/tr/td[@id='TextField2-bodyEl']/input[@id='TextField2-inputEl']")).SendKeys("#");

                                //Insert CHF currency exchange rate as "1.1631"
                                //click on the "Rate" field
                                executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//div[@id='CurrenciesGridPanel-body']/div/div/div/div/div/table[@id='NumberField1']/tbody/tr/td[@id='NumberField1-bodyEl']/table[@id='NumberField1-triggerWrap']/tbody/tr/td[@id='NumberField1-inputCell']/input[@id='NumberField1-inputEl']")));
                                System.Threading.Thread.Sleep(500);

                                //remove existing rate value from the "Rate" field
                                driver.FindElement(By.XPath("//div[@id='CurrenciesGridPanel-body']/div/div/div/div/div/table[@id='NumberField1']/tbody/tr/td[@id='NumberField1-bodyEl']/table[@id='NumberField1-triggerWrap']/tbody/tr/td[@id='NumberField1-inputCell']/input[@id='NumberField1-inputEl']")).Clear();

                                //Insert CHF currency exchange rate as "1.1631"
                                driver.FindElement(By.XPath("//div[@id='CurrenciesGridPanel-body']/div/div/div/div/div/table[@id='NumberField1']/tbody/tr/td[@id='NumberField1-bodyEl']/table[@id='NumberField1-triggerWrap']/tbody/tr/td[@id='NumberField1-inputCell']/input[@id='NumberField1-inputEl']")).SendKeys("1.1631");
                                
                                //Click on "Update" button
                                driver.FindElement(By.XPath("//*[@id='CurrenciesCombo-inputEl']")).SendKeys(Keys.Enter);
                                break;

                            case "RUB":
                                //Double-click on a row to open it for editing
                                new Actions(driver).DoubleClick(driver.FindElement(By.XPath("//div[@id='CurrenciesGridPanel-body']/div/table/tbody/tr/td/div[contains(text(), 'RUB')]"))).Perform();

                                //Insert "@" symbol for RUB currency
                                driver.FindElement(By.XPath("//div[@id='CurrenciesGridPanel-body']/div/div/div/div/div/table[@id='TextField2']/tbody/tr/td[@id='TextField2-bodyEl']/input[@id='TextField2-inputEl']")).SendKeys("@");

                                //Insert RUB currency exchange rate as "70.0723"
                                //click on the "Rate" field
                                executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//div[@id='CurrenciesGridPanel-body']/div/div/div/div/div/table[@id='NumberField1']/tbody/tr/td[@id='NumberField1-bodyEl']/table[@id='NumberField1-triggerWrap']/tbody/tr/td[@id='NumberField1-inputCell']/input[@id='NumberField1-inputEl']")));
                                System.Threading.Thread.Sleep(500);

                                //remove existing rate value from the "Rate" field
                                driver.FindElement(By.XPath("//div[@id='CurrenciesGridPanel-body']/div/div/div/div/div/table[@id='NumberField1']/tbody/tr/td[@id='NumberField1-bodyEl']/table[@id='NumberField1-triggerWrap']/tbody/tr/td[@id='NumberField1-inputCell']/input[@id='NumberField1-inputEl']")).Clear();

                                //Insert CHF currency exchange rate as "70.0723"
                                driver.FindElement(By.XPath("//div[@id='CurrenciesGridPanel-body']/div/div/div/div/div/table[@id='NumberField1']/tbody/tr/td[@id='NumberField1-bodyEl']/table[@id='NumberField1-triggerWrap']/tbody/tr/td[@id='NumberField1-inputCell']/input[@id='NumberField1-inputEl']")).SendKeys("70.0723");
                                
                                //Click on "Update" button
                                driver.FindElement(By.XPath("//*[@id='CurrenciesCombo-inputEl']")).SendKeys(Keys.Enter);
                                break;

                            case "GBP":
                                //Double-click on a row to open it for editing
                                new Actions(driver).DoubleClick(driver.FindElement(By.XPath("//div[@id='CurrenciesGridPanel-body']/div/table/tbody/tr/td/div[contains(text(), 'GBP')]"))).Perform();
                                                                
                                //Insert GBP currency exchange rate as "0.8791"
                                //click on the "Rate" field
                                executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//div[@id='CurrenciesGridPanel-body']/div/div/div/div/div/table[@id='NumberField1']/tbody/tr/td[@id='NumberField1-bodyEl']/table[@id='NumberField1-triggerWrap']/tbody/tr/td[@id='NumberField1-inputCell']/input[@id='NumberField1-inputEl']")));
                                System.Threading.Thread.Sleep(500);

                                //remove existing rate value from the "Rate" field
                                driver.FindElement(By.XPath("//div[@id='CurrenciesGridPanel-body']/div/div/div/div/div/table[@id='NumberField1']/tbody/tr/td[@id='NumberField1-bodyEl']/table[@id='NumberField1-triggerWrap']/tbody/tr/td[@id='NumberField1-inputCell']/input[@id='NumberField1-inputEl']")).Clear();

                                //Insert CHF currency exchange rate as "0.8791"
                                driver.FindElement(By.XPath("//div[@id='CurrenciesGridPanel-body']/div/div/div/div/div/table[@id='NumberField1']/tbody/tr/td[@id='NumberField1-bodyEl']/table[@id='NumberField1-triggerWrap']/tbody/tr/td[@id='NumberField1-inputCell']/input[@id='NumberField1-inputEl']")).SendKeys("0.8791");

                                //Click on "Update" button
                                driver.FindElement(By.XPath("//*[@id='CurrenciesCombo-inputEl']")).SendKeys(Keys.Enter);
                                break;

                            case "USD":
                                //Double-click on a row to open it for editing
                                new Actions(driver).DoubleClick(driver.FindElement(By.XPath("//div[@id='CurrenciesGridPanel-body']/div/table/tbody/tr/td/div[contains(text(), 'USD')]"))).Perform();

                                //Insert USD currency exchange rate as "1.2457"
                                //click on the "Rate" field
                                executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//div[@id='CurrenciesGridPanel-body']/div/div/div/div/div/table[@id='NumberField1']/tbody/tr/td[@id='NumberField1-bodyEl']/table[@id='NumberField1-triggerWrap']/tbody/tr/td[@id='NumberField1-inputCell']/input[@id='NumberField1-inputEl']")));
                                System.Threading.Thread.Sleep(500);

                                //remove existing rate value from the "Rate" field
                                driver.FindElement(By.XPath("//div[@id='CurrenciesGridPanel-body']/div/div/div/div/div/table[@id='NumberField1']/tbody/tr/td[@id='NumberField1-bodyEl']/table[@id='NumberField1-triggerWrap']/tbody/tr/td[@id='NumberField1-inputCell']/input[@id='NumberField1-inputEl']")).Clear();

                                //Insert CHF currency exchange rate as "0.8791"
                                driver.FindElement(By.XPath("//div[@id='CurrenciesGridPanel-body']/div/div/div/div/div/table[@id='NumberField1']/tbody/tr/td[@id='NumberField1-bodyEl']/table[@id='NumberField1-triggerWrap']/tbody/tr/td[@id='NumberField1-inputCell']/input[@id='NumberField1-inputEl']")).SendKeys("1.2457");

                                //Click on "Update" button
                                driver.FindElement(By.XPath("//*[@id='CurrenciesCombo-inputEl']")).SendKeys(Keys.Enter);
                                break;

                            default:
                                break;
                        }


                        //Next column
                        ColumnIndex = ColumnIndex + 1;

                        System.Threading.Thread.Sleep(500);

                    }

                    //Next row
                    RowIndex = RowIndex + 1;
                }


                System.Threading.Thread.Sleep(500);

            }
            catch (NoSuchElementException e)
            {
                logger.Error("No such element - Error while ADDING CURRENCY SYMBOL: " + e.Message);
            }

        }

                            



        private void LogInUserAdmin(String username, String password, String iframeId)
        {
            BuildShipperUser(username, password);

            var txtUserName = driver.FindElement(By.XPath("//*[@id='txtUsername-inputEl']"));
            var txtPassword = driver.FindElement(By.XPath("//*[@id='txtPassword-inputEl']"));
            var btn = driver.FindElement(By.XPath("//*[@id='LoginButton-btnEl']"));

            txtUserName.Clear();
            txtUserName.SendKeys(CurrentUser.UserName);
            txtPassword.Clear();
            txtPassword.SendKeys(CurrentUser.Password);

            /*
            var watch = System.Diagnostics.Stopwatch.StartNew();
            btn.Click();
            System.Threading.Thread.Sleep(3000);

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            var res = (double)elapsedMs / 1000;
            if (res > 10)
            {
                logger.Info(string.Format("#Warning '{0}' took quite a long time: {1} sec!", "Log In Click", res.ToString()));
            }*/

            btn.Click();

            //Waiting till the Carrier's main window is downloaded
            //explicitWaitsUntilElementLocated(20, "//iframe[@name='mmCtl13_IFrame']", "ALL TENDERS");
            explicitWaitsUntilElementLocated(20, iframeId, "PENDING TENDERS TAB on Admin's side");

            //When using an iframe, you will first have to switch to the iframe, before selecting the elements of that iframe.
            //driver.SwitchTo().Frame("mmCtl13_IFrame");
            driver.SwitchTo().Frame(driver.FindElement(By.XPath(iframeId)));

            //Waiting till the 'All tenders' grid is downloaded in the Carrier's main window
            explicitWaitsUntilElementLocated(20, "//*[@class='x-btn x-box-item x-toolbar-item x-btn-default-toolbar-small x-icon x-btn-icon x-btn-default-toolbar-small-icon']", "PENDING TENDERS GRID on Admin's side");

            //Exit iframe to have access to the main window's web-elements
            driver.SwitchTo().DefaultContent();

        }


        private void LogInUserCarrier(String username, String password, String iframeId)
        {
            BuildShipperUser(username, password);

            var txtUserName = driver.FindElement(By.XPath("//*[@id='txtUsername-inputEl']"));
            var txtPassword = driver.FindElement(By.XPath("//*[@id='txtPassword-inputEl']"));
            var btn = driver.FindElement(By.XPath("//*[@id='LoginButton-btnEl']"));

            txtUserName.Clear();
            txtUserName.SendKeys(CurrentUser.UserName);
            txtPassword.Clear();
            txtPassword.SendKeys(CurrentUser.Password);

            /*
            var watch = System.Diagnostics.Stopwatch.StartNew();
            btn.Click();
            System.Threading.Thread.Sleep(3000);

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            var res = (double)elapsedMs / 1000;
            if (res > 10)
            {
                logger.Info(string.Format("#Warning '{0}' took quite a long time: {1} sec!", "Log In Click", res.ToString()));
            }*/

            btn.Click();

            //Waiting till the Carrier's main window is downloaded
            //explicitWaitsUntilElementLocated(20, "//iframe[@name='mmCtl13_IFrame']", "ALL TENDERS");
            explicitWaitsUntilElementLocated(20, iframeId, "ALL TENDERS TAB on Carrier's side");

            //When using an iframe, you will first have to switch to the iframe, before selecting the elements of that iframe.
            //driver.SwitchTo().Frame("mmCtl13_IFrame");
            driver.SwitchTo().Frame(driver.FindElement(By.XPath(iframeId)));

            //Waiting till the 'All tenders' grid is downloaded in the Carrier's main window
            explicitWaitsUntilElementLocated(20, "//*[@class='row-imagecommand   icon-report ']", "ALL TENDERS GRID on Carrier's side");

            //Exit iframe to have access to the main window's web-elements
            driver.SwitchTo().DefaultContent();

        }


        private void Timer1() {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            LogInCurrentUser();
            int timeDiff = 20;

            if (timeDiff > 0)
            {
                // System.Threading.Thread.Sleep(TimeSpan.FromMinutes(timeDiff.TotalMinutes));

                System.Timers.Timer aTimer = new System.Timers.Timer();
                //aTimer.Elapsed += new System.Timers.ElapsedEventHandler();
                aTimer.Interval = 1000;
                aTimer.Enabled = true;
               aTimer.Start();
                var countDownDate = new DateTime();



                // aTimer.ToString();

                 executor.ExecuteScript("alert('WAITING TILL the BIDDING PHASE IS FINISHED and ANALYSIS IS ACTIVATED! Remaining time: ' + Math.floor((120000 % (1000 * 60)) / 1000)); showConfirmButton: false;");
                //executor.ExecuteScript("swal({ title: value, type: 'success', timer: 3000, showConfirmButton: false,});");
                

                System.Threading.Thread.Sleep(30000);
            }
        }

        private void WaitTillAnalysisGetsActivated()
        {
            //  tenderEndTime = "1:30 PM"; //THIS IS STUB - needs to be removed afterwards
            
            // use js executor as click have problem in IE
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

            //Convert "End of Tender" string time to calendar time
            DateTime oDate = Convert.ToDateTime(tenderEndTime);
            Console.WriteLine("END OF TENDER time taken from time picker: " + oDate);

            //Set converted "End of Tender" time to be 10 minutes later to give time for the analysis to get activated
            DateTime oDate2 = oDate.AddMinutes(10);
            Console.WriteLine("END OF TENDER time increased by 10 minutes : " + oDate2);

            //Get current time from shipper's Dashboard and convert it to calendar time
            LogInCurrentUser();

            //Convert current string time from the shipper's Dasboard to calendar time
            DateTime oDate3 = Convert.ToDateTime(getCurrentTimeFromShippersDashboardIn24Hformat());
            Console.WriteLine("CURRENT Time taken from Shipper's Dashboard: " + oDate3);

            //Calculate remaining time till the analysis activation 
            TimeSpan timeDiff = oDate2 - oDate3;
            Console.WriteLine("Time left till the ANALYSIS gets activated: " + timeDiff.TotalSeconds);
            


            //Convert TimeSpan to Int
            int intTimeDiff = (int)timeDiff.TotalSeconds;
            int intTimeDiffMinutes = (int)timeDiff.TotalMinutes;
            int intTimeDiffMiliSec = (int)timeDiff.TotalMilliseconds;

            driver.SwitchTo().DefaultContent();
            //driver.SwitchTo().Frame(1);

            // CountDownTimerForm.s =;
            // CountDownTimerForm.m = intTimeDiff;

            /*
            Form1 CountDownTimerForm = new Form1();
            CountDownTimerForm.s = 0;
            CountDownTimerForm.m = intTimeDiffMinutes;
            CountDownTimerForm.Show();*/





            //You need to start a new process with the name of the program you want to execute, as such:
            //System.Diagnostics.Process.Start("D:\\oDesk\\Softprise\\TestAutomation\\CCXUITestsDemo_4\\CountDownTimer2\\CountDownTimer2\\obj\\Debug\\CountDownTimer2.exe", intTimeDiff.ToString());
            //CountDownTimerForm.ProcessRequest(typeof(Program));


            //Wait till the analysis gets activated
           /* if (intTimeDiff > 0)
            {

                //////////////////////////////////////////////////////
                // CALLING EXTERNAL PYTHON FILE with COUNT DOWN TIMER
                //////////////////////////////////////////////////////          

                // full path of python interpreter  
                string python = "E:\\Users\\Alex Grischenko\\AppData\\Local\\Programs\\Python\\Python36-32\\python.exe";

                // python app to call  
                string projectCurrentPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
                Console.WriteLine("PROJECT's CURRENT PATH {0}", projectCurrentPath);
                var PythonFilePath = Path.Combine(projectCurrentPath, "Auxiliary_Files\\CountDownTimer.py");
                string myPythonApp = new Uri(PythonFilePath).LocalPath;
                Console.WriteLine("PROJECT's CURRENT PATH2 {0}", myPythonApp);



                // parameters to send Python script
                int var1 = intTimeDiff;


                // Create new process start info 
                ProcessStartInfo myProcessStartInfo = new ProcessStartInfo(python);

                // make sure we can read the output from stdout 
                myProcessStartInfo.UseShellExecute = false;
                myProcessStartInfo.RedirectStandardOutput = true;

                // start python app with 2 arguments  
                // 1st arguments is pointer to itself,  
                // 2nd argument is actual argument we want to send 
                myProcessStartInfo.Arguments = myPythonApp + " " + var1;

                //create a new process and start it
                Process myProcess = new Process();

                // assign start information to the process 
                myProcess.StartInfo = myProcessStartInfo;

                Console.WriteLine("Calling Python script with arguments {0}", var1);

                // start the process 
                myProcess.Start();

                // Read the standard output of the app we called.  
                // in order to avoid deadlock we will read output first 
                // and then wait for process terminate: 
                StreamReader myStreamReader = myProcess.StandardOutput;
                string myString = myStreamReader.ReadLine();

                //if you need to read multiple lines, you might use: 
                // string myString = myStreamReader.ReadToEnd()

                // wait exit signal from the app we called and then close it. 

                myProcess.WaitForExit();
                myProcess.Close();
                
                // write the output we got from python app 
                //Console.WriteLine("Value received from script: " + myString);


                //Thread.Sleep(TimeSpan.FromMinutes(timeDiff.TotalMinutes));
            }*/

            //Wait till the analysis gets activated
            executor.ExecuteScript("ShowWaitCountDownTimerWin('" + "Time left till the analysis gets activated:" + "', "+ intTimeDiff + ");");
            Thread.Sleep(intTimeDiffMiliSec);
                        

        }

        private void FindAndOpenTenderWithAnalysis()
        {            

            Actions action = new Actions(driver);

            // use js executor as click have problem in IE
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

            driver.SwitchTo().DefaultContent();

            //When using an iframe, you will first have to switch to the iframe, before selecting the elements of that iframe.
            driver.SwitchTo ( ).Frame ("mmCtl13_IFrame");
            //driver.SwitchTo().Frame(0);

            //Click on "Filter Your Search" button
            var btnFilter = driver.FindElement(By.XPath("//*[@id='filterButton-btnEl']"));
            executor.ExecuteScript("arguments[0].click();", btnFilter);

            Thread.Sleep(2000);

            //Enter tender's Reference number into search field
            var txtFilterTenderRefNum = driver.FindElement(By.XPath("//*[@id='filterRef-inputEl']"));
            //txtFilterTenderRefNum.SendKeys(globalTenderRefNum);  //Tender Reference Number
            txtFilterTenderRefNum.SendKeys("T1802070726");

            Thread.Sleep(1000);

            //Click on "Apply" button to search the tender with the requested title
            var btnFilterApply = driver.FindElement(By.XPath("//*[@id='button-1037-btnInnerEl']"));
            executor.ExecuteScript("arguments[0].click();", btnFilterApply);

            //Wait till the tender is found and displayed in search results on SHIPPER TENDERs(ALL) tab
            explicitWaitsUntilElementLocated(10, "//div[@id='ShipperGridPanel-body']/div/table/tbody/tr[2]/td/div/table/tbody/tr/td[14]/div/div/div[@class='row-imagecommand   icon-report ']", "Search Results - SHIPPER TENDERs(ALL) tab");
            Thread.Sleep(1000);


            //Get the status of found tender
            var iconTenderStatus = driver.FindElement(By.XPath("//div[@id='ShipperGridPanel-body']/div/table/tbody/tr[2]/td/div/table/tbody/tr/td[1]/div/img"));
            Thread.Sleep(1000);
            string tenderStatus = iconTenderStatus.GetAttribute("title").ToString();
            Console.WriteLine("Tender's status is :" + tenderStatus);

            //If tender's status is "Ready for analysis" then open it and go to analysis
            if (tenderStatus.Equals("Ready for analysis"))
            {

                //Click on tender's "View Tender Info" button
                var btnViewTenderInfo = driver.FindElement(By.XPath("//div[@id='ShipperGridPanel-body']/div/table/tbody/tr[2]/td/div/table/tbody/tr/td[14]/div/div/div[@class='row-imagecommand   icon-report ']"));
                // executor.ExecuteScript("arguments[0].click();", btnViewTenderInfo);
                action.MoveToElement(btnViewTenderInfo).Click().Build().Perform();

                driver.SwitchTo().DefaultContent();

                driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[contains(@src,'/TenderShipper/TenderShipperView/')]")));

                driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[contains(@src,'/Analysis/ScenarioResultsTab')]")));

                

                //Wait till the "Default scenario" tab is loading
                explicitWaitsUntilElementLocated(15, "//div[@id='scenarioResultChartPanel']", "DEFAULT ANALYSIS SCENARIO tab");

                Thread.Sleep(500);


                //Take screenshot of "Bidding Matrix" tab
                driver.SwitchTo().DefaultContent();
                TakeScreenshotOfWebElement("//div[@id='tpMain']", "actual_shipper_default_analysis_scenario.png");

                //Compare master and actual screenshots and create a separate screenshot with differences
                //CompareScreenshots("master_carrier_bidding_matrix.png", "actual_carrier_" + username + "_bidding_matrix.png", "difference_carrier_" + username + "_bidding_matrix.png");
                CompareScreenshots2("master_shipper_default_analysis_scenario.png", "actual_shipper_default_analysis_scenario.png", "difference_shipper_default_analysis_scenario.png", 10);

            }
            else
            {
                logger.Warn("Found tender's status is NOT 'READY FOR ANALYSIS'! Current tender status is " + tenderStatus.ToUpper() + ". The script was stopped.");
                driver.Quit();
            }
        }




        private void CheckAvailableAnalysisParts()
        {

            driver.SwitchTo().DefaultContent();
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[contains(@src,'/TenderShipper/TenderShipperView/')]")));
            
                        
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

            //Check which tender analysis parts are available in TENDER INFO - NAVIGATION panel
            IList<IWebElement> available_AnalysisParts = driver.FindElements(By.XPath("//div[@id='TenderStructurePanel-body']/div/table/tbody/descendant::tr"));

            int RowIndex = 1;

            //Loop the tender's analysis parts
            foreach (IWebElement item in available_AnalysisParts)
            {

                IList<IWebElement> TotalColumnCount = item.FindElements(By.XPath("td"));

                int ColumnIndex = 1;


                foreach (IWebElement colElement in TotalColumnCount)
                {

                    //Retrieve names of available tender's analysis parts
                    String analysisPartName = colElement.FindElement(By.XPath("div")).Text;
                    Console.WriteLine("Analysis part: " + analysisPartName);

                    switch (analysisPartName)
                    {

                        case "Analysis":
                            analysisPart_Information = true;
                            enabledAnalysis = item.GetAttribute("class").ToString();
                            Console.WriteLine("Analysis part: " + enabledAnalysis);
                            logger.Info("ANALYSIS item is avaialbale in 'Navigation' panel for shipper.");
                            break;
                        case "Default":
                            analysisPart_DefaultAnalysis = true;
                            enabledDefaultAnalysis = item.GetAttribute("class").ToString();
                            Console.WriteLine("Default scenario: " + enabledDefaultScenario);
                            logger.Info("DEFAULT analysis is avaialbale in 'Navigation' panel for shipper.");
                            break;
                        case "Overview Carriers":
                            analysisPart_OverviewCarriers = true;
                            enabledOverviewCarriers = item.GetAttribute("class").ToString();
                            Console.WriteLine("Overview Carriers part: " + enabledOverviewCarriers);
                            overviewCarriers = colElement;
                            logger.Info("OVERVIEW CARRIERS item is avaialbale in 'Navigation' panel for shipper.");
                            break;
                        case "Overview Scenarios":
                            analysisPart_OverviewScenarios = true;
                            enabledOverviewScenarios = item.GetAttribute("class").ToString();
                            Console.WriteLine("Overview Scenarios part: " + enabledOverviewScenarios);
                            overviewScenarios = colElement;
                            logger.Info("OVERVIEW SCENARIOS item is avaialbale in 'Navigation' panel for shipper.");
                            break;
                        case "Default scenario":
                            analysisPart_DefaultScenario = true;
                            enabledDefaultScenario = item.GetAttribute("class").ToString();
                            Console.WriteLine("Default scenario part: " + enabledDefaultScenario);
                            defaultScenario = colElement;
                            logger.Info("DEFAULT SCENARIO item is avaialbale in 'Navigation' panel for shipper.");
                            break;
                        
                        default:
                            break;
                    }
                    //Next column
                    ColumnIndex = ColumnIndex + 1;
                }
                //Next row
                RowIndex = RowIndex + 1;
            }


        }


        private void TestOverviewCarriers()
        {
            Actions action = new Actions(driver);
            
            driver.SwitchTo().DefaultContent();
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[contains(@src,'/TenderShipper/TenderShipperView/')]")));
                                    
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

            //Click on "Overview Carriers" item
            executor.ExecuteScript("arguments[0].click();", overviewCarriers);
            
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[contains(@src,'/Analysis/CarriersOverviewTab')]")));

            //Wait till the toolbar is loaded on the "Overview Carriers" tab
            explicitWaitsUntilElementLocated(15, "//div[@id='SplitButton1']/em/button/span[@id='SplitButton1-btnIconEl']", "Toolbar - OVERVIEW CARRIERS tab");
            Thread.Sleep(1000);


            //Get all buttons in the toolbar on the "Overview Carriers" tab
            IList<IWebElement> available_buttons = driver.FindElements(By.XPath("//div[@id='CarriersOverviewTab']/div[@class='x-toolbar x-docked x-toolbar-default x-docked-top x-toolbar-docked-top x-toolbar-default-docked-top x-box-layout-ct']/div[@class='x-box-inner ']/div/descendant::div"));


            //Loop the "Overview Carriers" tab's buttons
            foreach (IWebElement item in available_buttons)
            {               

                    //Retrieve names of available buttons in the toolbar
                    String buttonName = item.FindElement(By.XPath("em/button/span")).Text;
                    Console.WriteLine("Button in OVERVIEW CARRIERs toolbar: " + buttonName);

                    switch (buttonName)
                    {

                        case "Refresh":
                            btnRefresh_OverviewCarriers = item;
                            break;

                        case "Unit price":
                            btnUnitPrice_OverviewCarriers = item;
                            break;

                        case "Analysis":
                            btnAnalysis_OverviewCarriers = item;
                            break;

                        case "Show cents":
                            btnShowCents_OverviewCarriers = item;
                            break;

                        case "[Amount]":
                            btnAmount_OverviewCarriers = item;
                            break;                                               

                    default:
                            break;
                    }
                   
            }

            ////////////////////////////////////////////////////////////////////
            //  ANALYSIS - UNIT PRICE (OVERVIEW CARRIERS TAB)
            ////////////////////////////////////////////////////////////////////
            
            //Click on the Refresh button on the Overview Carriers tab toolbar i.e. ANALYSIS - UNIT PRICE
            executor.ExecuteScript("arguments[0].click();", btnRefresh_OverviewCarriers);

            //Wait till the ANALYSIS - UNIT PRICE table is loaded on the "Overview Carriers" tab
            waitTillDescendentElementsAvailable(15, "//div[@id='CarriersOverviewTab-body']/div", "class", "x-component x-component-default", "OVERVIEW CARRIERS tab - Analysis -> UnitPrice table");
            Thread.Sleep(1000);

            driver.SwitchTo().DefaultContent();
            
            //Take screenshot of "Overview Carriers" tab (i.e.ANALYSIS - UNIT PRICE view)
            TakeScreenshotOfWebElement("//iframe[contains(@src,'/TenderShipper/TenderShipperView/')]", "actual_shipper_OverviewCarriers_Analysis_UnitPrice.png");

            //Compare master and actual screenshots and create a separate screenshot with differences
            CompareScreenshots2("master_shipper_OverviewCarriers_Analysis_UnitPrice.png", "actual_shipper_OverviewCarriers_Analysis_UnitPrice.png", "difference_shipper_OverviewCarriers_Analysis_UnitPrice.png", 10);



            ////////////////////////////////////////////////////////////////////
            //  ANALYSIS - TOTAL SUM (OVERVIEW CARRIERS TAB)
            ////////////////////////////////////////////////////////////////////

            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[contains(@src,'/TenderShipper/TenderShipperView/')]")));
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[contains(@src,'/Analysis/CarriersOverviewTab')]")));

            //Click on UNIT PRICE button to open the dropdown menu
            var watch0 = System.Diagnostics.Stopwatch.StartNew();
            executor.ExecuteScript("arguments[0].click();", btnUnitPrice_OverviewCarriers);
            //Wait till page is reloaded
            watch0.Stop();
            var elapsedMs0 = watch0.ElapsedMilliseconds;
            var res0 = (double)elapsedMs0 / 1000;
            if (res0 > 10)
            {
                logger.Info(string.Format("#Warning It took quite a long time: {0} sec for UNIT PRICE dropdown menu to open on OVERVIEW CARRIERS tab!", res0.ToString()));
            }

            Thread.Sleep(1000);

            //Click on TOTAL SUM item in the UNIT PRICE dropdown menu on OVERVIEW CARRIERS tab
            executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//span[contains(text(), '[Total sum]')]")));
            Thread.Sleep(1000);

            //Click on the Refresh button on the Overview Carriers tab toolbar
            executor.ExecuteScript("arguments[0].click();", btnRefresh_OverviewCarriers);

            //Wait till the ANALYSIS - TOTAL SUM table is loaded on the "Overview Carriers" tab
            waitTillDescendentElementsAvailable(15, "//div[@id='CarriersOverviewTab-body']/div", "class", "x-component x-component-default", "OVERVIEW CARRIERS tab - Analysis -> TotalSum table");
            Thread.Sleep(1000);


            //Click on AMOUNT dropdown menu on OVERVIEW CARRIERS tab
            var watch01 = System.Diagnostics.Stopwatch.StartNew();
            executor.ExecuteScript("arguments[0].click();", btnAmount_OverviewCarriers);
            //Wait till page is reloaded
            watch01.Stop();
            var elapsedMs01 = watch01.ElapsedMilliseconds;
            var res01 = (double)elapsedMs01 / 1000;
            if (res01 > 10)
            {
                logger.Info(string.Format("#Warning It took quite a long time: {0} sec for AMOUNT dropdown menu to open on OVERVIEW CARRIERS tab!", res01.ToString()));
            }

            Thread.Sleep(1000);

            //Click on DIFFERENCE TO BASE PRICE (AMOUNT) item in the AMOUNT dropdown menu on OVERVIEW CARRIERS tab
            executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//span[contains(text(), 'Difference to Baseprice (Amount)')]")));
            Thread.Sleep(1000);

            //Click on DIFFERENCE TO BASE PRICE (PERCENT) item in the AMOUNT dropdown menu on OVERVIEW CARRIERS tab
            executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//span[contains(text(), 'Difference to Baseprice (Percent)')]")));
            Thread.Sleep(1000);


            //Click on AMOUNT dropdown menu on OVERVIEW CARRIERS tab (to close the drpdown)
            var watch02 = System.Diagnostics.Stopwatch.StartNew();
            //executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//span[contains(text(), '[Amount, BP(A), BP(%)]')]")));
            action.MoveToElement(driver.FindElement(By.XPath("//span[contains(text(), '[Amount, BP(A), BP(%)]')]"))).Click().Build().Perform();
            
            //Wait till page is reloaded
            watch02.Stop();
            var elapsedMs02 = watch02.ElapsedMilliseconds;
            var res02 = (double)elapsedMs02 / 1000;
            if (res02 > 10)
            {
                logger.Info(string.Format("#Warning It took quite a long time: {0} sec for AMOUNT dropdown menu to close on OVERVIEW CARRIERS tab!", res02.ToString()));
            }

            Thread.Sleep(1000);


            driver.SwitchTo().DefaultContent();
                     
            //Clicking on the page to remove focus from selected dropdowns/buttons in the toolbar
               /*  int xScrollPosition = 900; //enter your x co-ordinate  
                 int yScrollPosition = 400; //enter your y co-ordinate 

                 IWebElement element = driver.FindElement(By.XPath("//body[@id='ext-gen1018']"));
                 executor.ExecuteScript("window.scroll(" + xScrollPosition + ", " + yScrollPosition + ");");
                 action.MoveToElement(element, xScrollPosition, yScrollPosition).Click().Build().Perform();*/
                 executor.ExecuteScript("window.focus();");
            


            //Take screenshot of "Overview Carriers" tab (i.e.ANALYSIS - UNIT PRICE view)
            TakeScreenshotOfWebElement("//iframe[contains(@src,'/TenderShipper/TenderShipperView/')]", "actual_shipper_OverviewCarriers_Analysis_TotalSum.png");

            //Compare master and actual screenshots and create a separate screenshot with differences
            CompareScreenshots2("master_shipper_OverviewCarriers_Analysis_TotalSum.png", "actual_shipper_OverviewCarriers_Analysis_TotalSum.png", "difference_shipper_OverviewCarriers_Analysis_TotalSum.png", 10);



            ////////////////////////////////////////////////////////////////////
            //  ANALYSIS - NUMBER OF OFFERS (OVERVIEW CARRIERS TAB)
            ////////////////////////////////////////////////////////////////////

            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[contains(@src,'/TenderShipper/TenderShipperView/')]")));
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[contains(@src,'/Analysis/CarriersOverviewTab')]")));

            //Click on UNIT PRICE button to open the dropdown menu
            var watch1 = System.Diagnostics.Stopwatch.StartNew();
            executor.ExecuteScript("arguments[0].click();", btnUnitPrice_OverviewCarriers);
            //Wait till page is reloaded
            watch1.Stop();
            var elapsedMs1 = watch1.ElapsedMilliseconds;
            var res1 = (double)elapsedMs1 / 1000;
            if (res1 > 10)
            {
                logger.Info(string.Format("#Warning It took quite a long time: {0} sec for UNIT PRICE dropdown menu to open on OVERVIEW CARRIERS tab!", res1.ToString()));
            }

            Thread.Sleep(1000);

            //Click on NUMBER OF OFFERS item in the UNIT PRICE dropdown menu on OVERVIEW CARRIERS tab

            executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//span[contains(text(), 'Number of offers')]")));
            
            //Wait till the toolbar is updated and NOT DEFINED dropdown is displayed on the "Overview Carriers" tab
            explicitWaitsUntilElementLocated(15, "//span[contains(text(), '[Not Defined]')]", "Toolbar - NOT DEFINED dropdown - OVERVIEW CARRIERS tab");
            Thread.Sleep(1000);

            //Click on the Refresh button on the Overview Carriers tab toolbar
            executor.ExecuteScript("arguments[0].click();", btnRefresh_OverviewCarriers);

            //Wait till the ANALYSIS - TOTAL SUM table is loaded on the "Overview Carriers" tab
            waitTillDescendentElementsAvailable(15, "//div[@id='CarriersOverviewTab-body']/div", "class", "x-component x-component-default", "OVERVIEW CARRIERS tab - Analysis -> Number of Offers table");

            Thread.Sleep(1000);

            driver.SwitchTo().DefaultContent();

            //Clicking on the page to remove focus from selected dropdowns/buttons in the toolbar
            /* executor.ExecuteScript("window.scroll(" + xScrollPosition + ", " + yScrollPosition + ");");
             action.MoveToElement(element, xScrollPosition, yScrollPosition).Click().Build().Perform();*/
            executor.ExecuteScript("window.focus();");

            //Take screenshot of "Overview Carriers" tab (i.e.ANALYSIS - NUMBER OF OFFERS view)
            TakeScreenshotOfWebElement("//iframe[contains(@src,'/TenderShipper/TenderShipperView/')]", "actual_shipper_OverviewCarriers_Analysis_NumberOfOffers.png");

            //Compare master and actual screenshots and create a separate screenshot with differences
            CompareScreenshots2("master_shipper_OverviewCarriers_Analysis_NumberOfOffers.png", "actual_shipper_OverviewCarriers_Analysis_NumberOfOffers.png", "difference_shipper_OverviewCarriers_Analysis_NumberOfOffers.png", 10);



            ////////////////////////////////////////////////////////////////////
            //  ANALYSIS - RANKING (OVERVIEW CARRIERS TAB)
            ////////////////////////////////////////////////////////////////////

            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[contains(@src,'/TenderShipper/TenderShipperView/')]")));
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[contains(@src,'/Analysis/CarriersOverviewTab')]")));

            //Click on UNIT PRICE button to open the dropdown menu
            var watch2 = System.Diagnostics.Stopwatch.StartNew();
            executor.ExecuteScript("arguments[0].click();", btnUnitPrice_OverviewCarriers);
            //Wait till page is reloaded
            watch2.Stop();
            var elapsedMs2 = watch2.ElapsedMilliseconds;
            var res2 = (double)elapsedMs2 / 1000;
            if (res2 > 10)
            {
                logger.Info(string.Format("#Warning It took quite a long time: {0} sec for UNIT PRICE dropdown menu to open on OVERVIEW CARRIERS tab!", res2.ToString()));
            }

            Thread.Sleep(1000);

            //Click on RANKING item in the UNIT PRICE dropdown menu on OVERVIEW CARRIERS tab
            executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//span[contains(text(), 'Ranking')]")));

            //Wait till the toolbar is updated and NOT DEFINED dropdown is displayed on the "Overview Carriers" tab
            explicitWaitsUntilElementLocated(15, "//span[contains(text(), '[Not Defined]')]", "Toolbar - NOT DEFINED dropdown - OVERVIEW CARRIERS tab");
            Thread.Sleep(1000);

            //Click on the Refresh button on the Overview Carriers tab toolbar
            executor.ExecuteScript("arguments[0].click();", btnRefresh_OverviewCarriers);

            //Wait till the ANALYSIS - RANKING table is loaded on the "Overview Carriers" tab
            waitTillDescendentElementsAvailable(15, "//div[@id='CarriersOverviewTab-body']/div", "class", "x-component x-component-default", "OVERVIEW CARRIERS tab - Analysis -> Number of Offers table");

            Thread.Sleep(1000);

            driver.SwitchTo().DefaultContent();


            //Clicking on the page to remove focus from selected dropdowns/buttons in the toolbar
            /*executor.ExecuteScript("window.scroll(" + xScrollPosition + ", " + yScrollPosition + ");");
            action.MoveToElement(element, xScrollPosition, yScrollPosition).Click().Build().Perform();*/
            executor.ExecuteScript("window.focus();");

            //Take screenshot of "Overview Carriers" tab (i.e.ANALYSIS - RANKING view)
            TakeScreenshotOfWebElement("//iframe[contains(@src,'/TenderShipper/TenderShipperView/')]", "actual_shipper_OverviewCarriers_Analysis_Ranking.png");

            //Compare master and actual screenshots and create a separate screenshot with differences
            CompareScreenshots2("master_shipper_OverviewCarriers_Analysis_Ranking.png", "actual_shipper_OverviewCarriers_Analysis_Ranking.png", "difference_shipper_OverviewCarriers_Analysis_Ranking.png", 10);



            ////////////////////////////////////////////////////////////////////
            //  WORKSHEET - UNIT PRICE (OVERVIEW CARRIERS TAB)
            ////////////////////////////////////////////////////////////////////

            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[contains(@src,'/TenderShipper/TenderShipperView/')]")));
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[contains(@src,'/Analysis/CarriersOverviewTab')]")));
            

            //Click on ANALYSIS button to open the dropdown menu
            var watch3 = System.Diagnostics.Stopwatch.StartNew();
            executor.ExecuteScript("arguments[0].click();", btnAnalysis_OverviewCarriers);
            //Wait till page is reloaded
            watch3.Stop();
            var elapsedMs3 = watch3.ElapsedMilliseconds;
            var res3 = (double)elapsedMs3 / 1000;
            if (res3 > 10)
            {
                logger.Info(string.Format("#Warning It took quite a long time: {0} sec for ANALYSIS dropdown menu to open on OVERVIEW CARRIERS tab!", res3.ToString()));
            }

            Thread.Sleep(1000);

            //Click on WORKSHEET "Germany" item in the ANALYSIS dropdown menu on OVERVIEW CARRIERS tab
            executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//div[contains(text(), 'Germany')]")));
                        

            //Click on UNIT PRICE button to open the dropdown menu
            var watch4 = System.Diagnostics.Stopwatch.StartNew();
            executor.ExecuteScript("arguments[0].click();", btnUnitPrice_OverviewCarriers);
            //Wait till page is reloaded
            watch4.Stop();
            var elapsedMs4 = watch4.ElapsedMilliseconds;
            var res4 = (double)elapsedMs4 / 1000;
            if (res4 > 10)
            {
                logger.Info(string.Format("#Warning It took quite a long time: {0} sec for UNIT PRICE dropdown menu to open on OVERVIEW CARRIERS tab!", res4.ToString()));
            }

            Thread.Sleep(1000);

            //Click on UNIT PRICE item in the UNIT PRICE dropdown menu on OVERVIEW CARRIERS tab
            executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//span[contains(text(), 'Unit price')]")));
            
            //Wait till the toolbar is updated and SHOW CENTS button is displayed on the "Overview Carriers" tab
            explicitWaitsUntilElementLocated(15, "//span[contains(text(), 'Show cents')]", "Toolbar - SHOW CENTS button - OVERVIEW CARRIERS tab");
            Thread.Sleep(1000);

            //Click on the Refresh button on the Overview Carriers tab toolbar
            executor.ExecuteScript("arguments[0].click();", btnRefresh_OverviewCarriers);

            //Wait till the WORKSHEET "Germany" - UNIT PRICE table is loaded on the "Overview Carriers" tab
            waitTillDescendentElementsAvailable(15, "//div[@id='CarriersOverviewTab-body']/div", "class", "x-component x-component-default", "OVERVIEW CARRIERS tab - Worksheet 'Germany' -> UnitPrice table");

            Thread.Sleep(1000);


            //Click on the "Show Cents" button on the Overview Carriers tab toolbar
            var watch5 = System.Diagnostics.Stopwatch.StartNew();
            executor.ExecuteScript("arguments[0].click();", btnShowCents_OverviewCarriers);
            //Wait till page is reloaded
            watch5.Stop();
            var elapsedMs5 = watch5.ElapsedMilliseconds;
            var res5 = (double)elapsedMs5 / 1000;
            if (res5 > 10)
            {
                logger.Info(string.Format("#Warning It took quite a long time: {0} sec after clicking on SHOW CENTS button on OVERVIEW CARRIERS tab!", res5.ToString()));
            }


            //Wait till the ANALYSIS - UNIT PRICE table is updated on the "Overview Carriers" tab
            waitTillDescendentElementsAvailable(15, "//div[@id='CarriersOverviewTab-body']/div", "class", "x-component x-component-default", "OVERVIEW CARRIERS tab - Analysis -> Number of Offers table");

            Thread.Sleep(1000);


            driver.SwitchTo().DefaultContent();

            //Clicking on the page to remove focus from selected dropdowns/buttons in the toolbar
            /*executor.ExecuteScript("window.scroll(" + xScrollPosition + ", " + yScrollPosition + ");");
            action.MoveToElement(element, xScrollPosition, yScrollPosition).Click().Build().Perform();*/
            executor.ExecuteScript("window.focus();");

            //Take screenshot of "Overview Carriers" tab (i.e.ANALYSIS - UNIT PRICE view)
            TakeScreenshotOfWebElement("//iframe[contains(@src,'/TenderShipper/TenderShipperView/')]", "actual_shipper_OverviewCarriers_Worksheet_UnitPrice.png");

            //Compare master and actual screenshots and create a separate screenshot with differences
            CompareScreenshots2("master_shipper_OverviewCarriers_Worksheet_UnitPrice.png", "actual_shipper_OverviewCarriers_Worksheet_UnitPrice.png", "difference_shipper_OverviewCarriers_Worksheet_UnitPrice.png", 20);




            ////////////////////////////////////////////////////////////////////
            //  WORKSHEET - TOTAL SUM (OVERVIEW CARRIERS TAB)
            ////////////////////////////////////////////////////////////////////

            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[contains(@src,'/TenderShipper/TenderShipperView/')]")));
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[contains(@src,'/Analysis/CarriersOverviewTab')]")));

            
            //Click on UNIT PRICE button to open the dropdown menu
            var watch6 = System.Diagnostics.Stopwatch.StartNew();
            executor.ExecuteScript("arguments[0].click();", btnUnitPrice_OverviewCarriers);
            //Wait till page is reloaded
            watch6.Stop();
            var elapsedMs6 = watch6.ElapsedMilliseconds;
            var res6 = (double)elapsedMs6 / 1000;
            if (res6 > 10)
            {
                logger.Info(string.Format("#Warning It took quite a long time: {0} sec for UNIT PRICE dropdown menu to open on OVERVIEW CARRIERS tab!", res6.ToString()));
            }

            Thread.Sleep(1000);

            //Click on TOTAL SUM item in the UNIT PRICE dropdown menu on OVERVIEW CARRIERS tab
            executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//span[contains(text(), '[Total sum]')]")));
            Thread.Sleep(1000);


            //Click on the Refresh button on the Overview Carriers tab toolbar
            executor.ExecuteScript("arguments[0].click();", btnRefresh_OverviewCarriers);

            //Wait till the WORKSHEET "Germany" - TOTAL SUM table is loaded on the "Overview Carriers" tab
            waitTillDescendentElementsAvailable(15, "//div[@id='CarriersOverviewTab-body']/div", "class", "x-component x-component-default", "OVERVIEW CARRIERS tab - Worksheet 'Germany' -> TotalSum table");

            Thread.Sleep(1000);
            

            driver.SwitchTo().DefaultContent();

            //Clicking on the page to remove focus from selected dropdowns/buttons in the toolbar
            /*executor.ExecuteScript("window.scroll(" + xScrollPosition + ", " + yScrollPosition + ");");
            action.MoveToElement(element, xScrollPosition, yScrollPosition).Click().Build().Perform();*/
            executor.ExecuteScript("window.focus();");

            //Take screenshot of "Overview Carriers" tab (i.e.WORKSHEET "Germany" - TOTALSUM view)
            TakeScreenshotOfWebElement("//iframe[contains(@src,'/TenderShipper/TenderShipperView/')]", "actual_shipper_OverviewCarriers_Worksheet_TotalSum.png");

            //Compare master and actual screenshots and create a separate screenshot with differences
            CompareScreenshots2("master_shipper_OverviewCarriers_Worksheet_TotalSum.png", "actual_shipper_OverviewCarriers_Worksheet_TotalSum.png", "difference_shipper_OverviewCarriers_Worksheet_TotalSum.png", 10);




            ////////////////////////////////////////////////////////////////////
            //  WORKSHEET - NUMBER OF OFFERS - SUM OF FIELDS (OVERVIEW CARRIERS TAB)
            ////////////////////////////////////////////////////////////////////

            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[contains(@src,'/TenderShipper/TenderShipperView/')]")));
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[contains(@src,'/Analysis/CarriersOverviewTab')]")));


            //Click on UNIT PRICE button to open the dropdown menu
            var watch7 = System.Diagnostics.Stopwatch.StartNew();
            executor.ExecuteScript("arguments[0].click();", btnUnitPrice_OverviewCarriers);
            //Wait till page is reloaded
            watch7.Stop();
            var elapsedMs7 = watch7.ElapsedMilliseconds;
            var res7 = (double)elapsedMs7 / 1000;
            if (res7 > 10)
            {
                logger.Info(string.Format("#Warning It took quite a long time: {0} sec for UNIT PRICE dropdown menu to open on OVERVIEW CARRIERS tab!", res7.ToString()));
            }

            Thread.Sleep(1000);

            //Click on NUMBER OF OFFERS item in the UNIT PRICE dropdown menu on OVERVIEW CARRIERS tab
            executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//span[contains(text(), 'Number of offers')]")));

            //Wait till the toolbar is updated and NOT DEFINED dropdown is displayed on the "Overview Carriers" tab
            explicitWaitsUntilElementLocated(15, "//span[contains(text(), '[Not Defined]')]", "Toolbar - NOT DEFINED dropdown - OVERVIEW CARRIERS tab");
            Thread.Sleep(1000);


            //Click on NOT DEFINED dropdown menu on OVERVIEW CARRIERS tab
            var watch8 = System.Diagnostics.Stopwatch.StartNew();
            executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//span[contains(text(), '[Not Defined]')]")));
            //Wait till page is reloaded
            watch8.Stop();
            var elapsedMs8 = watch8.ElapsedMilliseconds;
            var res8 = (double)elapsedMs8 / 1000;
            if (res8 > 10)
            {
                logger.Info(string.Format("#Warning It took quite a long time: {0} sec for NOT DEFINED dropdown menu to open on OVERVIEW CARRIERS tab!", res8.ToString()));
            }

            Thread.Sleep(1000);

            //Click on SUM OF FIELDS item in the NOT DEFINED dropdown menu on OVERVIEW CARRIERS tab
            executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//span[contains(text(), 'Sum of fields')]")));
            Thread.Sleep(1000);
            

            //Click on the Refresh button on the Overview Carriers tab toolbar
            executor.ExecuteScript("arguments[0].click();", btnRefresh_OverviewCarriers);

            //Wait till the WORKSHEET "Germany" - NUMBER OF OFFERS table is loaded on the "Overview Carriers" tab
            waitTillDescendentElementsAvailable(15, "//div[@id='CarriersOverviewTab-body']/div", "class", "x-component x-component-default", "OVERVIEW CARRIERS tab - Worksheet 'Germany' -> Number of Offers table");

            Thread.Sleep(1000);


            driver.SwitchTo().DefaultContent();

            //Clicking on the page to remove focus from selected dropdowns/buttons in the toolbar
            /*executor.ExecuteScript("window.scroll(" + xScrollPosition + ", " + yScrollPosition + ");");
            action.MoveToElement(element, xScrollPosition, yScrollPosition).Click().Build().Perform();*/
            executor.ExecuteScript("window.focus();");

            //Take screenshot of "Overview Carriers" tab (i.e.WORKSHEET "Germany" - NUMBER OF OFFERS view)
            TakeScreenshotOfWebElement("//iframe[contains(@src,'/TenderShipper/TenderShipperView/')]", "actual_shipper_OverviewCarriers_Worksheet_NumberOfOffers.png");

            //Compare master and actual screenshots and create a separate screenshot with differences
            CompareScreenshots2("master_shipper_OverviewCarriers_Worksheet_NumberOfOffers.png", "actual_shipper_OverviewCarriers_Worksheet_NumberOfOffers.png", "difference_shipper_OverviewCarriers_Worksheet_NumberOfOffers.png", 10);




            ////////////////////////////////////////////////////////////////////
            //  WORKSHEET - RANKING - SUM OF FIELDS (OVERVIEW CARRIERS TAB)
            ////////////////////////////////////////////////////////////////////

            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[contains(@src,'/TenderShipper/TenderShipperView/')]")));
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[contains(@src,'/Analysis/CarriersOverviewTab')]")));


            //Click on UNIT PRICE button to open the dropdown menu
            var watch9 = System.Diagnostics.Stopwatch.StartNew();
            executor.ExecuteScript("arguments[0].click();", btnUnitPrice_OverviewCarriers);
            //Wait till page is reloaded
            watch9.Stop();
            var elapsedMs9 = watch9.ElapsedMilliseconds;
            var res9 = (double)elapsedMs9 / 1000;
            if (res9 > 10)
            {
                logger.Info(string.Format("#Warning It took quite a long time: {0} sec for UNIT PRICE dropdown menu to open on OVERVIEW CARRIERS tab!", res9.ToString()));
            }

            Thread.Sleep(1000);

            //Click on RANKING item in the UNIT PRICE dropdown menu on OVERVIEW CARRIERS tab
            executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//span[contains(text(), 'Ranking')]")));


            //Wait till the toolbar is updated and NOT DEFINED dropdown is displayed on the "Overview Carriers" tab
            explicitWaitsUntilElementLocated(15, "//span[contains(text(), '[Sum of fields]')]", "Toolbar - NOT DEFINED dropdown - OVERVIEW CARRIERS tab");
            Thread.Sleep(1000);

            //Click on the Refresh button on the Overview Carriers tab toolbar
            executor.ExecuteScript("arguments[0].click();", btnRefresh_OverviewCarriers);

            //Wait till the WORKSHEET "Germany" - RANKING table is loaded on the "Overview Carriers" tab
             waitTillDescendentElementsAvailable(15, "//div[@id='CarriersOverviewTab-body']/div", "class", "x-component x-component-default", "OVERVIEW CARRIERS tab - Worksheet 'Germany' -> Ranking table");

            Thread.Sleep(1000);


            driver.SwitchTo().DefaultContent();

            //Clicking on the page to remove focus from selected dropdowns/buttons in the toolbar
            /* executor.ExecuteScript("window.scroll(" + xScrollPosition + ", " + yScrollPosition + ");");
             action.MoveToElement(element, xScrollPosition, yScrollPosition).Click().Build().Perform();*/
            executor.ExecuteScript("window.focus();");

            //Take screenshot of "Overview Carriers" tab (i.e.WORKSHEET "Germany" - RANKING view)
            TakeScreenshotOfWebElement("//iframe[contains(@src,'/TenderShipper/TenderShipperView/')]", "actual_shipper_OverviewCarriers_Worksheet_Ranking.png");

            //Compare master and actual screenshots and create a separate screenshot with differences
            CompareScreenshots2("master_shipper_OverviewCarriers_Worksheet_Ranking.png", "actual_shipper_OverviewCarriers_Worksheet_Ranking.png", "difference_shipper_OverviewCarriers_Worksheet_Ranking.png", 10);

        }

        private void CreateManualAllocationScenarioWithFilters()
        {
            Actions action = new Actions(driver);

            driver.SwitchTo().DefaultContent();
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[contains(@src,'/TenderShipper/TenderShipperView/')]")));

            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

            var overviewScenariosTab = driver.FindElement(By.XPath("//div[@id='TabPanel']/div/div/div[2]/div/div[3]"));

            //Click on "Overview Scenarios" item
            executor.ExecuteScript("arguments[0].click();", overviewScenariosTab);

            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[contains(@src,'/Analysis/ScenarioOverviewTab')]")));

            //Wait till the toolbar is loaded on the "Overview Scenarios" tab
            explicitWaitsUntilElementLocated(15, "//div[@id='SplitButton1']/em/button/span[@id='SplitButton1-btnIconEl']", "Toolbar - OVERVIEW SCENARIOS tab");

            Thread.Sleep(1000);
                        

            //Click on the NEW SCENARIO button on the Overview Scenarios tab toolbar
            executor.ExecuteScript("arguments[0].click();", btnNewScenario_OverviewScenarios);

            driver.SwitchTo().DefaultContent();

            //Wait till the CREATE NEW SCENARIO wizard is loaded
            //waitTillDescendentElementsAvailable(15, "//div[@id='ScenarioFormPanel-targetEl']/table", "class", "x-container x-form-fieldcontainer x-form-item x-box-item x-container-default x-vbox-form-item", "CREATE NEW SCENARIO wizard - STEP# 1");
            explicitWaitsUntilElementLocated(15, "//input[@id='ManualAllocation-inputEl']", "CREATE NEW SCENARIO wizard - STEP# 1");
            
            Thread.Sleep(1000);
                       

            //Take screenshot of "Create New Scenario - Step# 1" wizard
            TakeScreenshotOfWebElement("//div[@class='x-window x-layer x-window-default x-closable x-window-closable x-window-default-closable']", "actual_shipper_CreateNewScenarios_Step1.png");

            //Compare master and actual screenshots and create a separate screenshot with differences
            CompareScreenshots2("master_shipper_CreateNewScenarios_Step1.png", "actual_shipper_CreateNewScenarios_Step1.png", "difference_shipper_CreateNewScenarios_Step1.png", 10);


            /////////////////////////////////////////////////////////////////
            ///  FILL OUT STEP#1 of "CREATE NEW SCENARIO" WIZARD
            /////////////////////////////////////////////////////////////////

            //Clear "Name" field and enter "ManAlloc_SOC" text
            driver.FindElement(By.XPath("//input[@id='Name-inputEl']")).Clear();
            driver.FindElement(By.XPath("//input[@id='Name-inputEl']")).SendKeys("ManAlloc_SOC");

            Thread.Sleep(1000);

            //Select "Consider incomplete offers" check-box
            //driver.FindElement(By.XPath("//div[@id='ScenarioFormPanel-targetEl']/div[@class='x-container x-box-item x-container-default x-box-layout-ct']/div/div/table[2]/tbody/tr/td[@class='x-form-item-body x-form-cb-wrap']/input[@class='x-form-field x-form-checkbox']")).Click();
            executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//div[@id='ScenarioFormPanel-targetEl']/div[@class='x-container x-box-item x-container-default x-box-layout-ct']/div/div/table[2]/tbody/tr/td[@class='x-form-item-body x-form-cb-wrap']/input[@class='x-form-field x-form-checkbox']")));

            Thread.Sleep(1000);

            //Select "Manual allocation" option-box
            // driver.FindElement(By.XPath("//table[@id='ManualAllocation']/tbody/tr[@id='ManualAllocation-inputRow']/td[@id='ManualAllocation-bodyEl']/input[@id='ManualAllocation-inputEl']")).Click();
            executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//input[@id='ManualAllocation-inputEl']")));

            Thread.Sleep(1000);

            //Click on "NEXT" button
            //driver.FindElement(By.XPath("//button[@id='nextBtn-btnEl']")).Click();
            executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//button[@id='nextBtn-btnEl']")));

            //Wait till the tender tree is loaded on the Step#2 of "Overview Scenarios" tab
           // explicitWaitsUntilElementLocated(15, "//div[@id='ScenarioTreePanel-body']/div/table/tbody/tr[@class='x-grid-row  x-grid-tree-node-leaf']/td[@class='x-grid-cell-treecolumn x-grid-cell x-grid-cell-treecolumn-1082   x-grid-cell-first']/div[@class='x-grid-cell-inner']/img[@class='x-tree-icon x-tree-icon-leaf']", "OVERVIEW SCENARIOS tab - STEP#2");
           // waitTillDescendentElementsAvailable(15, "//div[@id='ScenarioTreePanel-body']/div/table/tbody/tr", "class", "x-grid-row  x-grid-tree-node-leaf", "OVERVIEW SCENARIOS tab - STEP#2");
            explicitWaitsUntilElementLocated(15, "//div[@id='ScenarioTreePanel-body']/div/table/tbody/tr[4]", "OVERVIEW SCENARIOS tab - STEP#2");

            Thread.Sleep(1000);

            //Take screenshot of "Create New Scenario - Step# 2" wizard
            TakeScreenshotOfWebElement("//div[@class='x-window x-layer x-window-default x-closable x-window-closable x-window-default-closable']", "actual_shipper_CreateNewScenarios_Step2.png");

            //Compare master and actual screenshots and create a separate screenshot with differences
            CompareScreenshots2("master_shipper_CreateNewScenarios_Step2.png", "actual_shipper_CreateNewScenarios_Step2.png", "difference_shipper_CreateNewScenarios_Step2.png", 10);




            /////////////////////////////////////////////////////////////////
            ///  FILL OUT STEP#2 of "CREATE NEW SCENARIO" WIZARD
            /////////////////////////////////////////////////////////////////

            //Click on the lowest row to select the level of worksheet "Germany"
            executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//div[@id='ScenarioTreePanel-body']/div/table/tbody/tr[4]")));

            Thread.Sleep(1000);

            //Check if "Add New Rule" button got enabled in the toolbar and click on it (if it is enabled)
            Console.WriteLine("'Add New Rule' button class: " + driver.FindElement(By.XPath("//div[@id='ScenarioTreePanel']/div[1]/div/div/div[1]")).GetAttribute("class"));


            if (driver.FindElement(By.XPath("//div[@id='ScenarioTreePanel']/div[1]/div/div/div[1]")).GetAttribute("class").Equals("x-btn x-box-item x-toolbar-item x-btn-default-toolbar-small x-icon-text-left x-btn-icon-text-left x-btn-default-toolbar-small-icon-text-left"))
            {

                executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//div[@id='ScenarioTreePanel']/div[1]/div/div/div[1]/em/button")));

                Thread.Sleep(1000);

                //Check whether all 5 rules are available in the dropdown

                string[] scenarioRulesExpected = { "Number of carriers", "Best price", "Price limits", "Dropdowns", "Selection of carriers" };
                string[] scenarioRulesActual = new string [5];
                int x = 0;

                IList<IWebElement> available_rules = driver.FindElements(By.XPath("//div[@class='x-panel x-layer x-panel-default x-menu']/div/div[@class='x-box-inner x-vertical-box-overflow-body']/div[2]/descendant::div"));


                //Loop the "Overview Scenarios" tab's buttons
                foreach (IWebElement item in available_rules)
                {
                    String ruleName = item.FindElement(By.XPath("a/span")).Text;
                    Console.WriteLine("Rule name: " + ruleName);

                    //Fill the array with the names of the rule detected in the "ADD NEW RULE" dropdown
                    scenarioRulesActual[x] = ruleName;

                    x++;

                }

                Array.Sort(scenarioRulesActual);
                Array.Sort(scenarioRulesExpected);

                //Compare whether the actual and expected rules are the same
                if (scenarioRulesActual.SequenceEqual(scenarioRulesExpected))
                {

                    //Console.WriteLine("ALL RULES ARE in PLACE!");
                    logger.Info("ALL RULES ARE in PLACE in the 'ADD NEW RULE' dropdown on STEP#2 of 'CREATE NEW SCENARIO' wizard.");


                    //Create "Selection of Carriers" rule
                    CreateSelectionOfCarriersRule();

                    //Create "Dropdowns" rule
                    CreateDropdownsRule();

                    //Create "Price Limits" rule
                    CreatePriceLimitsRule();

                    //Create "Best Price" rule
                    CreateBestPriceRule();

                    //Create "Number of Carriers" rule
                    CreateNumberOfCarriersRule();

                    //Check that "Edit rule" and "Delete rule" buttons get enabled on selecting a rule
                    EditDeleteButtonsGetEnabled();


                }
                else {

                    //Console.WriteLine("RULES ARE NOT THE SAME!");
                    logger.Error("NOT ALL RULES WERE FOUND in the 'ADD NEW RULE' dropdown on STEP#2 of 'CREATE NEW SCENARIO' wizard!");
                    driver.Quit();
                }

            }
            else {

                logger.Error("Button 'ADD NEW RULE' on STEP#2 of 'CREATE NEW SCENARIO' wizard is disabled after selecting the level of worksheet!");
                driver.Quit();

            }


        }



        private void EditDeleteButtonsGetEnabled()
        {
            Actions action = new Actions(driver);
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;


            //Click on the "Number of Carriers" rule in the worksheet "Germany"
            executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//div[@id='ScenarioTreePanel-body']/div/table/tbody/tr/td/div[contains(text(), 'Number of carriers')]")));

            Thread.Sleep(1000);

            //Check if "Edit Rule" button got enabled in the toolbar and click on it (if it is enabled)
            String value = driver.FindElement(By.XPath("//div[@id='ScenarioTreePanel']/div/div/div/div[2]/em/button")).GetAttribute("disabled");
            if (value == null)
            {

                var buttonEdutRule = driver.FindElement(By.XPath("//div[@id='ScenarioTreePanel']/div/div/div/div/em/button/span[contains(text(),'Edit rule')]"));
                executor.ExecuteScript("arguments[0].click();", buttonEdutRule);

                //Wait till 'Number of Carriers' form gets loaded
                explicitWaitsUntilElementLocated(15, "//div[@id='RuleSettingsForm-innerCt']", "Create New Rule - NUMBER of CARRIERS form");

                Thread.Sleep(1000);


                //Take screenshot of "Create New Rule - NUMBER of CARRIERS" form
                TakeScreenshotOfWebElement("//div[contains(@style,'width: 450px; height: 370px;')]", "actual_shipper_EditScenarios_NumberOfCarriersRule.png");

                //Compare master and actual screenshots and create a separate screenshot with differences
                CompareScreenshots2("master_shipper_CreateNewScenarios_NumberOfCarriersRule.png", "actual_shipper_EditScenarios_NumberOfCarriersRule.png", "difference_shipper_EditScenarios_NumberOfCarriersRule.png", 10);


                //Click on 'Close' button on 
                var buttonSaveDropdowns = driver.FindElement(By.XPath("//div[contains(@style,'width: 450px; height: 370px;')]/div[3]/div/div/div/em/button/span[contains(text(),'Close')]"));
                executor.ExecuteScript("arguments[0].click();", buttonSaveDropdowns);

                //Wait till the tender tree is loaded on the Step#2 of "Overview Scenarios" tab after closing 'Edit Scenarios - Number of Carriers' form
                explicitWaitsUntilElementLocated(15, "//div[@id='ScenarioTreePanel-body']/div/table/tbody/tr[4]", "OVERVIEW SCENARIOS tab - STEP#2 after closing 'Edit Scenarios - Number of Carriers' form");
                
                Thread.Sleep(1000);

            }
            else
            {
                logger.Error("EDIT RULE button is disabled after having selected existing NUMBER OF CARRIERS rule!");
                driver.Quit();
            }

            
            Console.WriteLine("'Edit Rule' button class: " + driver.FindElement(By.XPath("//div[@id='ScenarioTreePanel']/div[1]/div/div/div[1]")).GetAttribute("class"));


            if (driver.FindElement(By.XPath("//div[@id='ScenarioTreePanel']/div[1]/div/div/div[1]")).GetAttribute("class").Equals("x-btn x-box-item x-toolbar-item x-btn-default-toolbar-small x-icon-text-left x-btn-icon-text-left x-btn-default-toolbar-small-icon-text-left"))

                //Wait till 'Selection of Carriers' form gets loaded
                explicitWaitsUntilElementLocated(15, "//div[@id='selCarriers-body']", "Create New Rule - SELECTION OF CARRIERS form");

            Thread.Sleep(1000);
            
        }



        private void CreateSelectionOfCarriersRule()
        {
            Actions action = new Actions(driver);
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
        
                    
            var itemSelectionOfCarriers = driver.FindElement(By.XPath("//div[@class='x-panel x-layer x-panel-default x-menu']/div/div[@class='x-box-inner x-vertical-box-overflow-body']/div[2]/div/a/span[contains(text(),'Selection of carriers')]"));
            executor.ExecuteScript("arguments[0].click();", itemSelectionOfCarriers);

            //Wait till 'Selection of Carriers' form gets loaded
            explicitWaitsUntilElementLocated(15, "//div[@id='selCarriers-body']", "Create New Rule - SELECTION OF CARRIERS form");
            Thread.Sleep(1000);


            //Select all check-boxes in column "Include"
            try
            {
                IList<IWebElement> rowsInclude = driver.FindElements(By.XPath("//div[@id='selCarriers-body']/div/table/tbody/descendant::tr"));

                int RowIndex = 1;

                //Loop the table's rows
                foreach (IWebElement item in rowsInclude)
                {

                    //Retrieve all columns from the row
                    IList<IWebElement> TotalColumnCount = item.FindElements(By.XPath("td"));

                    int ColumnIndex = 1;

                    //Loop the columns of a row
                    foreach (IWebElement colElement in TotalColumnCount)
                    {
                        if (ColumnIndex == 3)
                        {
                            //var check_box = colElement.FindElement(By.XPath("div[@class='x-grid-cell-inner ']/div[@class='x-grid-checkheader']"));
                            //executor.ExecuteScript("arguments[0].click();", check_box);
                            //colElement.FindElement(By.XPath("div[@class='x-grid-cell-inner ']/div[@class='x-grid-checkheader']")).Click();
                            action.MoveToElement(colElement.FindElement(By.XPath("div[@class='x-grid-cell-inner ']/div[@class='x-grid-checkheader']"))).Click().Build().Perform();
                        }

                        //Next column
                        ColumnIndex = ColumnIndex + 1;

                        Thread.Sleep(500);

                    }

                    //Next row
                    RowIndex = RowIndex + 1;
                }

                Thread.Sleep(500);

            }
            catch (NoSuchElementException e)
            {
                logger.Error("No such element - Error while detecting rows and column in the grid on the 'Selection of Carriers' form: " + e.Message);
            }


            //driver.SwitchTo().DefaultContent();

            //Take screenshot of "Create New Rule - Selection of Carriers" form
            TakeScreenshotOfWebElement("//div[contains(@style,'width: 450px; height: 370px;')]", "actual_shipper_CreateNewScenarios_SelectionOfCarriersRule.png");

            //Compare master and actual screenshots and create a separate screenshot with differences
            CompareScreenshots2("master_shipper_CreateNewScenarios_SelectionOfCarriersRule.png", "actual_shipper_CreateNewScenarios_SelectionOfCarriersRule.png", "difference_shipper_CreateNewScenarios_SelectionOfCarriersRule.png", 10);


            //Click on 'Save' button on 
            var buttonSaveSelectionOfCarriers = driver.FindElement(By.XPath("//div[contains(@style,'width: 450px; height: 370px;')]/div[3]/div/div/div/em/button/span[contains(text(),'Save')]"));
            executor.ExecuteScript("arguments[0].click();", buttonSaveSelectionOfCarriers);

            //Wait till the tender tree is loaded on the Step#2 of "Overview Scenarios" tab after adding 'Selection of Carriers' rule
            explicitWaitsUntilElementLocated(15, "//div[@id='ScenarioTreePanel-body']/div/table/tbody/tr[4]", "OVERVIEW SCENARIOS tab - STEP#2 after adding 'Selection of Carriers' rule");
            Thread.Sleep(1000);

            //Take screenshot of "Create New Scenario - Step# 2" after adding 'Selection of Carriers' rule
            TakeScreenshotOfWebElement("//div[@class='x-window x-layer x-window-default x-closable x-window-closable x-window-default-closable']", "actual_shipper_CreateNewScenarios_Step2_SelectionOfCarriersRule.png");

            //Compare master and actual screenshots and create a separate screenshot with differences
            CompareScreenshots2("master_shipper_CreateNewScenarios_Step2_SelectionOfCarriersRule.png", "actual_shipper_CreateNewScenarios_Step2_SelectionOfCarriersRule.png", "difference_shipper_CreateNewScenarios_Step2_SelectionOfCarriersRule.png", 10);

        }




        private void CreateDropdownsRule()
        {
            Actions action = new Actions(driver);
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;


            //Click on the lowest row to select the level of worksheet "Germany"
            executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//div[@id='ScenarioTreePanel-body']/div/table/tbody/tr[4]")));

            Thread.Sleep(1000);

            //Click on "Add New Rule" button
             executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//div[@id='ScenarioTreePanel']/div[1]/div/div/div[1]/em/button")));

            Thread.Sleep(1000);

            //Click on "Dropdowns" rule item
            var itemDropdowns = driver.FindElement(By.XPath("//div[@class='x-panel x-layer x-panel-default x-menu']/div/div[@class='x-box-inner x-vertical-box-overflow-body']/div[2]/div/a/span[contains(text(),'Dropdowns')]"));
            executor.ExecuteScript("arguments[0].click();", itemDropdowns);

            //Wait till 'Dropdowns' form gets loaded
            explicitWaitsUntilElementLocated(15, "//div[@id='DropdownsTree']", "Create New Rule - DROPDOWNS form");
            Thread.Sleep(1000);


            //Click to open the "Filter calculated on the basis of:" dropdown and select "Sum of Rows"
            var filterDropdown = driver.FindElement(By.XPath("//table[@id='AnalysisSummary-triggerWrap']/tbody/tr/td[@class='x-trigger-cell']/div[@class='x-trigger-index-0 x-form-trigger x-form-arrow-trigger x-form-trigger-last x-unselectable']"));
            executor.ExecuteScript("arguments[0].click();", filterDropdown);

            Thread.Sleep(1000);

            var filterDropdownSumOfRowsValue = driver.FindElement(By.XPath("//div[@class='x-boundlist x-boundlist-floating x-layer x-boundlist-default']/div[@class='x-boundlist-list-ct']/ul/li[contains(text(),'Sum of rows')]"));
            executor.ExecuteScript("arguments[0].click();", filterDropdownSumOfRowsValue);

            Thread.Sleep(1000);



            //Click to select all items from the "Ports" dropdown
            var dropdownPorts = driver.FindElement(By.XPath("//div[@id='DropdownsTree-body']/div/table/tbody/tr/td/div[contains(text(),'Ports')]/input[@class='x-tree-checkbox']"));
            executor.ExecuteScript("arguments[0].click();", dropdownPorts);

            Thread.Sleep(1000);

                       

            //Take screenshot of "Create New Rule - DROPDOWNS" form
            TakeScreenshotOfWebElement("//div[contains(@style,'width: 450px; height: 370px;')]", "actual_shipper_CreateNewScenarios_DropdownsRule.png");

            //Compare master and actual screenshots and create a separate screenshot with differences
            CompareScreenshots2("master_shipper_CreateNewScenarios_DropdownsRule.png", "actual_shipper_CreateNewScenarios_DropdownsRule.png", "difference_shipper_CreateNewScenarios_DropdownsRule.png", 10);


            //Click on 'Save' button on 
            var buttonSaveDropdowns = driver.FindElement(By.XPath("//div[contains(@style,'width: 450px; height: 370px;')]/div[3]/div/div/div/em/button/span[contains(text(),'Save')]"));
            executor.ExecuteScript("arguments[0].click();", buttonSaveDropdowns);

            //Wait till the tender tree is loaded on the Step#2 of "Overview Scenarios" tab after adding 'Dropdowns' rule
            explicitWaitsUntilElementLocated(15, "//div[@id='ScenarioTreePanel-body']/div/table/tbody/tr[4]", "OVERVIEW SCENARIOS tab - STEP#2 after adding 'Dropdowns' rule");
            Thread.Sleep(1000);

            //Take screenshot of "Create New Scenario - Step# 2" after adding 'Dropdowns' rule
            TakeScreenshotOfWebElement("//div[@class='x-window x-layer x-window-default x-closable x-window-closable x-window-default-closable']", "actual_shipper_CreateNewScenarios_Step2_DropdownsRule.png");

            //Compare master and actual screenshots and create a separate screenshot with differences
            CompareScreenshots2("master_shipper_CreateNewScenarios_Step2_DropdownsRule.png", "actual_shipper_CreateNewScenarios_Step2_DropdownsRule.png", "difference_shipper_CreateNewScenarios_Step2_DropdownsRule.png", 10);

        }





        private void CreatePriceLimitsRule()
        {
            Actions action = new Actions(driver);
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;


            //Click on the lowest row to select the level of worksheet "Germany"
            executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//div[@id='ScenarioTreePanel-body']/div/table/tbody/tr[4]")));

            Thread.Sleep(1000);

            //Click on "Add New Rule" button
            executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//div[@id='ScenarioTreePanel']/div[1]/div/div/div[1]/em/button")));

            Thread.Sleep(1000);

            //Click on "Price limits" rule item
            var itemDropdowns = driver.FindElement(By.XPath("//div[@class='x-panel x-layer x-panel-default x-menu']/div/div[@class='x-box-inner x-vertical-box-overflow-body']/div[2]/div/a/span[contains(text(),'Price limits')]"));
            executor.ExecuteScript("arguments[0].click();", itemDropdowns);

            //Wait till 'Price Limits' form gets loaded
            explicitWaitsUntilElementLocated(15, "//div[@id='RuleSettingsForm-innerCt']", "Create New Rule - PRICE LIMITS form");
            Thread.Sleep(1000);


            //Click to open the "Filter calculated on the basis of:" dropdown and select "Sum of Fields"
            var filterDropdown = driver.FindElement(By.XPath("//table[@id='AnalysisSummary-triggerWrap']/tbody/tr/td[@class='x-trigger-cell']/div[@class='x-trigger-index-0 x-form-trigger x-form-arrow-trigger x-form-trigger-last x-unselectable']"));
            executor.ExecuteScript("arguments[0].click();", filterDropdown);
                                                                                                                                                         
            Thread.Sleep(1000);

            var filterDropdownSumOfRowsValue = driver.FindElement(By.XPath("//div[@class='x-boundlist x-boundlist-floating x-layer x-boundlist-default']/div[@class='x-boundlist-list-ct']/ul/li[contains(text(),'Sum of fields')]"));
            executor.ExecuteScript("arguments[0].click();", filterDropdownSumOfRowsValue);

            Thread.Sleep(1000);



            //Click to select "Price should be calculated on the basis of TOTAL COST" option-box
            var optionTotalCost = driver.FindElement(By.XPath("//input[@id='TotalCoast-inputEl']"));
            executor.ExecuteScript("arguments[0].click();", optionTotalCost);

            Thread.Sleep(1000);



            //Click to select "Consider Partial Offers" check-box if it is enabled
            String value = driver.FindElement(By.XPath("//input[@id='IsConsiderPartialOffers-inputEl']")).GetAttribute("disabled");
            if (value == null)                
            {

                var checkboxConsiderPartialOffers = driver.FindElement(By.XPath("//input[@id='IsConsiderPartialOffers-inputEl']"));
                executor.ExecuteScript("arguments[0].click();", checkboxConsiderPartialOffers);

                Thread.Sleep(1000);

            }
            else {
                logger.Error("CONSIDER PARTIAL OFFERS check-box is disabled after having selected TOTAL COST option on 'Create New Rule - Price Limits' form!");
                driver.Quit();
            }


            //Clear "MAX % higher than base price" field and enter 51%
            driver.FindElement(By.XPath("//input[@id='MaxPrice-inputEl']")).Clear();
            driver.FindElement(By.XPath("//input[@id='MaxPrice-inputEl']")).SendKeys("51");

            Thread.Sleep(1000);


            //Clear "MIN % lower than base price" field and enter 36%
            driver.FindElement(By.XPath("//input[@id='MinPrice-inputEl']")).Clear();
            driver.FindElement(By.XPath("//input[@id='MinPrice-inputEl']")).SendKeys("36");

            Thread.Sleep(1000);



            //Take screenshot of "Create New Rule - PRICE LIMITS" form
            TakeScreenshotOfWebElement("//div[contains(@style,'width: 450px; height: 370px;')]", "actual_shipper_CreateNewScenarios_PriceLimitsRule.png");

            //Compare master and actual screenshots and create a separate screenshot with differences
            CompareScreenshots2("master_shipper_CreateNewScenarios_PriceLimitsRule.png", "actual_shipper_CreateNewScenarios_PriceLimitsRule.png", "difference_shipper_CreateNewScenarios_PriceLimitsRule.png", 10);


            //Click on 'Save' button on 
            var buttonSaveDropdowns = driver.FindElement(By.XPath("//div[contains(@style,'width: 450px; height: 370px;')]/div[3]/div/div/div/em/button/span[contains(text(),'Save')]"));
            executor.ExecuteScript("arguments[0].click();", buttonSaveDropdowns);

            //Wait till the tender tree is loaded on the Step#2 of "Overview Scenarios" tab after adding 'Price Limits' rule
            explicitWaitsUntilElementLocated(15, "//div[@id='ScenarioTreePanel-body']/div/table/tbody/tr[4]", "OVERVIEW SCENARIOS tab - STEP#2 after adding 'Price Limits' rule");
            Thread.Sleep(1000);

            //Take screenshot of "Create New Scenario - Step# 2" after adding 'Price Limits' rule
            TakeScreenshotOfWebElement("//div[@class='x-window x-layer x-window-default x-closable x-window-closable x-window-default-closable']", "actual_shipper_CreateNewScenarios_Step2_PriceLimitsRule.png");

            //Compare master and actual screenshots and create a separate screenshot with differences
            CompareScreenshots2("master_shipper_CreateNewScenarios_Step2_PriceLimitsRule.png", "actual_shipper_CreateNewScenarios_Step2_PriceLimitsRule.png", "difference_shipper_CreateNewScenarios_Step2_PriceLimitsRule.png", 10);

        }





        private void CreateBestPriceRule()
        {
            Actions action = new Actions(driver);
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;


            //Click on the lowest row to select the level of worksheet "Germany"
            executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//div[@id='ScenarioTreePanel-body']/div/table/tbody/tr[4]")));

            Thread.Sleep(1000);

            //Click on "Add New Rule" button
            executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//div[@id='ScenarioTreePanel']/div[1]/div/div/div[1]/em/button")));

            Thread.Sleep(1000);

            //Click on "Best Price" rule item
            var itemDropdowns = driver.FindElement(By.XPath("//div[@class='x-panel x-layer x-panel-default x-menu']/div/div[@class='x-box-inner x-vertical-box-overflow-body']/div[2]/div/a/span[contains(text(),'Best price')]"));
            executor.ExecuteScript("arguments[0].click();", itemDropdowns);

            //Wait till 'Best Price' form gets loaded
            explicitWaitsUntilElementLocated(15, "//div[@id='RuleSettingsForm-innerCt']", "Create New Rule - BEST PRICE form");
            Thread.Sleep(1000);


            //Click to open the "Filter calculated on the basis of:" dropdown and select "Sum of Fields"
            var filterDropdown = driver.FindElement(By.XPath("//table[@id='AnalysisSummary-triggerWrap']/tbody/tr/td[@class='x-trigger-cell']/div[@class='x-trigger-index-0 x-form-trigger x-form-arrow-trigger x-form-trigger-last x-unselectable']"));
            executor.ExecuteScript("arguments[0].click();", filterDropdown);

            Thread.Sleep(1000);

            var filterDropdownSumOfRowsValue = driver.FindElement(By.XPath("//div[@class='x-boundlist x-boundlist-floating x-layer x-boundlist-default']/div[@class='x-boundlist-list-ct']/ul/li[contains(text(),'Sum of fields')]"));
            executor.ExecuteScript("arguments[0].click();", filterDropdownSumOfRowsValue);

            Thread.Sleep(1000);



            //Click to select "Price should be calculated on the basis of TOTAL COST" option-box
            var optionTotalCost = driver.FindElement(By.XPath("//input[@id='TotalCoast-inputEl']"));
            executor.ExecuteScript("arguments[0].click();", optionTotalCost);

            Thread.Sleep(1000);



            //Click to select "Consider Partial Offers" check-box if it is enabled
            String value = driver.FindElement(By.XPath("//input[@id='IsConsiderPartialOffers-inputEl']")).GetAttribute("disabled");
            if (value == null)
            {

                var checkboxConsiderPartialOffers = driver.FindElement(By.XPath("//input[@id='IsConsiderPartialOffers-inputEl']"));
                executor.ExecuteScript("arguments[0].click();", checkboxConsiderPartialOffers);

                Thread.Sleep(1000);

            }
            else
            {
                logger.Error("CONSIDER PARTIAL OFFERS check-box is disabled after having selected TOTAL COST option on 'Create New Rule - Best Price' form!");
                driver.Quit();
            }


            //Clear "MAX % higher than best price" field and enter 540%
            driver.FindElement(By.XPath("//input[@id='MaxBestPrice-inputEl']")).Clear();
            driver.FindElement(By.XPath("//input[@id='MaxBestPrice-inputEl']")).SendKeys("540");

            Thread.Sleep(1000);

            

            //Take screenshot of "Create New Rule - BEST PRICE" form
            TakeScreenshotOfWebElement("//div[contains(@style,'width: 450px; height: 370px;')]", "actual_shipper_CreateNewScenarios_BestPriceRule.png");

            //Compare master and actual screenshots and create a separate screenshot with differences
            CompareScreenshots2("master_shipper_CreateNewScenarios_BestPriceRule.png", "actual_shipper_CreateNewScenarios_BestPriceRule.png", "difference_shipper_CreateNewScenarios_BestPriceRule.png", 10);


            //Click on 'Save' button on 
            var buttonSaveDropdowns = driver.FindElement(By.XPath("//div[contains(@style,'width: 450px; height: 370px;')]/div[3]/div/div/div/em/button/span[contains(text(),'Save')]"));
            executor.ExecuteScript("arguments[0].click();", buttonSaveDropdowns);

            //Wait till the tender tree is loaded on the Step#2 of "Overview Scenarios" tab after adding 'Best Price' rule
            explicitWaitsUntilElementLocated(15, "//div[@id='ScenarioTreePanel-body']/div/table/tbody/tr[4]", "OVERVIEW SCENARIOS tab - STEP#2 after adding 'Best Price' rule");
            Thread.Sleep(1000);

            //Take screenshot of "Create New Scenario - Step# 2" after adding 'Best Price' rule
            TakeScreenshotOfWebElement("//div[@class='x-window x-layer x-window-default x-closable x-window-closable x-window-default-closable']", "actual_shipper_CreateNewScenarios_Step2_BestPriceRule.png");

            //Compare master and actual screenshots and create a separate screenshot with differences
            CompareScreenshots2("master_shipper_CreateNewScenarios_Step2_BestPriceRule.png", "actual_shipper_CreateNewScenarios_Step2_BestPriceRule.png", "difference_shipper_CreateNewScenarios_Step2_BestPriceRule.png", 10);

        }




        private void CreateNumberOfCarriersRule()
        {
            Actions action = new Actions(driver);
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;


            //Click on the lowest row to select the level of worksheet "Germany"
            executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//div[@id='ScenarioTreePanel-body']/div/table/tbody/tr[4]")));

            Thread.Sleep(1000);

            //Click on "Add New Rule" button
            executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//div[@id='ScenarioTreePanel']/div[1]/div/div/div[1]/em/button")));

            Thread.Sleep(1000);

            //Click on "Number of Carriers" rule item
            var itemDropdowns = driver.FindElement(By.XPath("//div[@class='x-panel x-layer x-panel-default x-menu']/div/div[@class='x-box-inner x-vertical-box-overflow-body']/div[2]/div/a/span[contains(text(),'Number of carriers')]"));
            executor.ExecuteScript("arguments[0].click();", itemDropdowns);

            //Wait till 'Number of Carriers' form gets loaded
            explicitWaitsUntilElementLocated(15, "//div[@id='RuleSettingsForm-innerCt']", "Create New Rule - NUMBER of CARRIERS form");
            Thread.Sleep(1000);


            //Click to open the "Filter calculated on the basis of:" dropdown and select "Sum of Fields"
            var filterDropdown = driver.FindElement(By.XPath("//table[@id='AnalysisSummary-triggerWrap']/tbody/tr/td[@class='x-trigger-cell']/div[@class='x-trigger-index-0 x-form-trigger x-form-arrow-trigger x-form-trigger-last x-unselectable']"));
            executor.ExecuteScript("arguments[0].click();", filterDropdown);

            Thread.Sleep(1000);

            var filterDropdownSumOfRowsValue = driver.FindElement(By.XPath("//div[@class='x-boundlist x-boundlist-floating x-layer x-boundlist-default']/div[@class='x-boundlist-list-ct']/ul/li[contains(text(),'Sum of fields')]"));
            executor.ExecuteScript("arguments[0].click();", filterDropdownSumOfRowsValue);

            Thread.Sleep(1000);

            //Clear "Number of carriers at this level" field and enter 3
            driver.FindElement(By.XPath("//input[@id='NumCarriers-inputEl']")).Clear();
            driver.FindElement(By.XPath("//input[@id='NumCarriers-inputEl']")).SendKeys("3");

            Thread.Sleep(1000);

            //Click to select "Price should be calculated on the basis of TOTAL COST" option-box
            var optionTotalCost = driver.FindElement(By.XPath("//input[@id='TotalCoast-inputEl']"));
            executor.ExecuteScript("arguments[0].click();", optionTotalCost);

            Thread.Sleep(1000);

            
            //Click to select "Consider Partial Offers" check-box if it is enabled
            String value = driver.FindElement(By.XPath("//input[@id='IsConsiderPartialOffers-inputEl']")).GetAttribute("disabled");
            if (value == null)
            {

                var checkboxConsiderPartialOffers = driver.FindElement(By.XPath("//input[@id='IsConsiderPartialOffers-inputEl']"));
                executor.ExecuteScript("arguments[0].click();", checkboxConsiderPartialOffers);

                Thread.Sleep(1000);

            }
            else
            {
                logger.Error("CONSIDER PARTIAL OFFERS check-box is disabled after having selected TOTAL COST option on 'Create New Rule - Number of Carriers' form!");
                driver.Quit();
            }
                                    

            Thread.Sleep(1000);

            
            //Take screenshot of "Create New Rule - NUMBER of CARRIERS" form
            TakeScreenshotOfWebElement("//div[contains(@style,'width: 450px; height: 370px;')]", "actual_shipper_CreateNewScenarios_NumberOfCarriersRule.png");

            //Compare master and actual screenshots and create a separate screenshot with differences
            CompareScreenshots2("master_shipper_CreateNewScenarios_NumberOfCarriersRule.png", "actual_shipper_CreateNewScenarios_NumberOfCarriersRule.png", "difference_shipper_CreateNewScenarios_NumberOfCarriersRule.png", 10);


            //Click on 'Save' button on 
            var buttonSaveDropdowns = driver.FindElement(By.XPath("//div[contains(@style,'width: 450px; height: 370px;')]/div[3]/div/div/div/em/button/span[contains(text(),'Save')]"));
            executor.ExecuteScript("arguments[0].click();", buttonSaveDropdowns);

            //Wait till the tender tree is loaded on the Step#2 of "Overview Scenarios" tab after adding 'Number of Carriers' rule
            explicitWaitsUntilElementLocated(15, "//div[@id='ScenarioTreePanel-body']/div/table/tbody/tr[4]", "OVERVIEW SCENARIOS tab - STEP#2 after adding 'Number of Carriers' rule");
            Thread.Sleep(1000);

            //Take screenshot of "Create New Scenario - Step# 2" after adding 'Number of Carriers' rule
            TakeScreenshotOfWebElement("//div[@class='x-window x-layer x-window-default x-closable x-window-closable x-window-default-closable']", "actual_shipper_CreateNewScenarios_Step2_NumberOfCarriersRule.png");

            //Compare master and actual screenshots and create a separate screenshot with differences
            CompareScreenshots2("master_shipper_CreateNewScenarios_Step2_NumberOfCarriersRule.png", "actual_shipper_CreateNewScenarios_Step2_NumberOfCarriersRule.png", "difference_shipper_CreateNewScenarios_Step2_NumberOfCarriersRule.png", 10);

        }




        private void TestOverviewScenarios()
        {
            Actions action = new Actions(driver);

            driver.SwitchTo().DefaultContent();
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[contains(@src,'/TenderShipper/TenderShipperView/')]")));

            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

            //Click on "Overview Scenarios" item
            executor.ExecuteScript("arguments[0].click();", overviewScenarios);

            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[contains(@src,'/Analysis/ScenarioOverviewTab')]")));

            //Wait till the toolbar is loaded on the "Overview Scenarios" tab
            explicitWaitsUntilElementLocated(15, "//div[@id='SplitButton1']/em/button/span[@id='SplitButton1-btnIconEl']", "Toolbar - OVERVIEW SCENARIOS tab");
            Thread.Sleep(1000);


            //Get all buttons in the toolbar on the "Overview Scenarios" tab
            IList<IWebElement> available_buttons = driver.FindElements(By.XPath("//div[@id='ScenarioTreePanel']/div[@class='x-toolbar x-docked x-toolbar-default x-docked-top x-toolbar-docked-top x-toolbar-default-docked-top x-box-layout-ct']/div[@class='x-box-inner ']/div/descendant::div"));


            //Loop the "Overview Scenarios" tab's buttons
            foreach (IWebElement item in available_buttons)
            {
                if (!item.GetAttribute("class").Equals("x-toolbar-separator x-box-item x-toolbar-item x-toolbar-separator-horizontal")) { 
                    //Retrieve names of available buttons in the toolbar
                    String buttonName = item.FindElement(By.XPath("em/button/span")).Text;
                    Console.WriteLine("Button in OVERVIEW SCENARIOS toolbar: " + buttonName);

                switch (buttonName)
                {

                    case "Refresh":
                        btnRefresh_OverviewScenarios = item;
                        break;

                    case "New Scenario":
                        btnNewScenario_OverviewScenarios = item;
                        break;

                    case "Unit price":
                        btnUnitPrice_OverviewScenarios = item;
                        break;

                    case "[No Comparison]":
                        btnNoComparison_OverviewScenarios = item;
                        break;

                    case "Export [Xlsx]":
                        btnExportToXLS_OverviewScenarios = item;
                        break;

                    default:
                        break;
                }
            }

            }


            //Click on the Refresh button on the Overview Scenarios tab toolbar i.e. UNIT PRICE - NO COMPARISON
            executor.ExecuteScript("arguments[0].click();", btnRefresh_OverviewScenarios);

            //Wait till the UNIT PRICE - NO COMPARISON table is loaded on the "Overview Scenarios" tab
            waitTillDescendentElementsAvailable(15, "//div[@id='ScenarioTreePanel-body']/div/table/tbody/tr[4]", "class", "x-grid-row  x-grid-tree-node-leaf", "OVERVIEW SCENARIOS tab - UnitPrice -> No Comparison table");
            Thread.Sleep(1000);

            driver.SwitchTo().DefaultContent();

            //Take screenshot of "Overview Scenarios" tab (i.e. UNIT PRICE -> NO COMPARISON view)
            TakeScreenshotOfWebElement("//iframe[contains(@src,'/TenderShipper/TenderShipperView/')]", "actual_shipper_OverviewScenarios_UnitPrice_NoComparison.png");

            //Compare master and actual screenshots and create a separate screenshot with differences
            CompareScreenshots2("master_shipper_OverviewScenarios_UnitPrice_NoComparison.png", "actual_shipper_OverviewScenarios_UnitPrice_NoComparison.png", "difference_shipper_OverviewScenarios_UnitPrice_NoComparison.png", 10);



            //////////////////////////////////////////////////////////////////////////////////////////
            //Graphical panel - select WORKSHEET -> TOTAL SUM -> AMOUNTS and click on REFRESH button 
            //////////////////////////////////////////////////////////////////////////////////////////
                                   
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[contains(@src,'/TenderShipper/TenderShipperView/')]")));
                        
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[contains(@src,'/Analysis/ScenarioOverviewTab')]")));


            //Click to open 'Tender Level' dropdown on the graphical panel
            executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//table[@id='ddfTenderGraphicTreePanel']/tbody/tr/td[@id='ddfTenderGraphicTreePanel-bodyEl']/table/tbody/tr/td[2]/div")));

            //Wait till the 'Tender Level' dropdown is loaded on the graphical panel (on the "Overview Scenarios" tab)
            explicitWaitsUntilElementLocated(15, "//div[@id='TenderGraphicTreePanel-body']/div/table/tbody/tr[4]/td/div[contains(text(),'Germany')]", "Tender level dropdown - Graphical Panel - OVERVIEW SCENARIOS tab");
            Thread.Sleep(1000);


            //Select 'Germany' worksheet from 'Tender Level' dropdown on the graphical panel
            executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//div[@id='TenderGraphicTreePanel-body']/div/table/tbody/tr[4]/td/div[contains(text(),'Germany')]")));
            Thread.Sleep(1000);


            //Click to open 'UnitPrice/TotalSUM' dropdown on the graphical panel
            executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//div[@class='x-fieldset-body']/div[@class='x-container x-container-default x-box-layout-ct']/div[@class='x-box-inner ']/div/table[1]/tbody/tr/td[@class='x-form-item-body ']/table/tbody/tr/td[2]/div")));

            //Wait till the 'UnitPrice/TotalSUM' dropdown is loaded on the graphical panel (on the "Overview Scenarios" tab)
            explicitWaitsUntilElementLocated(15, "//div[@class='x-boundlist x-boundlist-floating x-layer x-boundlist-default']/div[@class='x-boundlist-list-ct']/ul//li[contains(text(),'[Total sum]')]", "'UnitPrice/TotalSUM' dropdown - Graphical Panel - OVERVIEW SCENARIOS tab");
            Thread.Sleep(1000);

            //Select 'Total SUM' from 'UnitPrice/TotalSUM' dropdown on the graphical panel
            executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//div[@class='x-boundlist x-boundlist-floating x-layer x-boundlist-default']/div[@class='x-boundlist-list-ct']/ul//li[contains(text(),'[Total sum]')]")));
            Thread.Sleep(1000);


            //Click to open 'Amounts' dropdown on the graphical panel
            executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//div[@class='x-fieldset-body']/div[@class='x-container x-container-default x-box-layout-ct']/div[@class='x-box-inner ']/div/table[2]/tbody/tr/td[@class='x-form-item-body ']/table/tbody/tr/td[2]/div")));
            Thread.Sleep(1000);

            //Wait till the 'Amounts' dropdown is loaded on the graphical panel (on the "Overview Scenarios" tab)
            explicitWaitsUntilElementLocated(15, "//div[@class='x-boundlist x-boundlist-floating x-layer x-boundlist-default']/div[@class='x-boundlist-list-ct']/ul//li[contains(text(),'Difference (Amount)')]", "'Amount' dropdown - Graphical Panel - OVERVIEW SCENARIOS tab");
            Thread.Sleep(1000);

            //Select 'Difference (Amount)' from 'Amounts' dropdown on the graphical panel
            executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//div[@class='x-boundlist x-boundlist-floating x-layer x-boundlist-default']/div[@class='x-boundlist-list-ct']/ul//li[contains(text(),'Difference (Amount)')]")));
            Thread.Sleep(1000);


            //Click to open 'Refresh' button on the graphical panel
            executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//div[@class='x-btn x-box-item x-btn-default-small x-icon-text-left x-btn-icon-text-left x-btn-default-small-icon-text-left']/em/button/span[contains(text(), 'Refresh')]")));
            Thread.Sleep(1000);

            //Wait till the GRAPICAL PANEL is updated on the "Overview Scenarios" tab
            explicitWaitsUntilElementLocated(15, "//div[@class='x-surface x-box-item x-surface-default']", "GRAPHICAL PANEL -> 'Overview Scenrios' tab");
            Thread.Sleep(1000);

                        

            //Take screenshot of the Graphical Panel on "Overview Scenarios" tab
            TakeScreenshotOfWebElement("//div[@class='x-panel x-border-item x-box-item x-panel-default']", "actual_shipper_OverviewScenarios_GraphicalPanel.png");

            //Compare master and actual screenshots and create a separate screenshot with differences
            CompareScreenshots2("master_shipper_OverviewScenarios_GraphicalPanel.png", "actual_shipper_OverviewScenarios_GraphicalPanel.png", "difference_OverviewScenarios_GraphicalPanel.png", 10);

        }


        private void TestLowerGridOfDefaultScenario() {
            Actions action = new Actions(driver);

            driver.SwitchTo().DefaultContent();
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[contains(@src,'/TenderShipper/TenderShipperView')]")));
                       

            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

            //Close "Default Scenario2"
            //executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//div[@id='TenderStructurePanel-body']/div/table/tbody/tr/td/div[contains(text(),'Default scenario2')]")));
            //Thread.Sleep(1000);

            //Click to select "Default Scenario" check-box
            //executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//div[@id='TenderStructurePanel-body']/div/table/tbody/tr/td/div[contains(text(),'Default scenario')]")));
            //Thread.Sleep(5000);
            



            //Click on "Default Scenario" tab
            executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//div[@id='TabPanel']/div/div/div[@class='x-box-inner x-horizontal-box-overflow-body']/div/div/em/button/span[contains(text(),'Default scenario')]")));

            Thread.Sleep(1000);

            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[contains(@src,'/Analysis/ScenarioResultsTab')]")));
                        

            //Get all buttons in the toolbar in the lower grid on the "Default Scenario" tab
            IList<IWebElement> available_buttons = driver.FindElements(By.XPath("//div[@id='ScenarioTablePanel']/div[@class='x-toolbar x-docked x-toolbar-default x-docked-top x-toolbar-docked-top x-toolbar-default-docked-top x-box-layout-ct']/div[@class='x-box-inner ']/div/descendant::div"));


            //Loop the "Default Scenario" tab's buttons for the lower grid
            foreach (IWebElement item in available_buttons)
            {

                if (!item.GetAttribute("class").Equals("x-component x-box-item x-toolbar-item x-component-default"))
                {
                    if (!item.GetAttribute("class").Equals("x-toolbar-separator x-box-item x-toolbar-item x-toolbar-separator-horizontal"))
                    {

                        //Retrieve names of available buttons in the toolbar
                        String buttonName = item.FindElement(By.XPath("em/button/span")).Text;
                        Console.WriteLine("Button in DEFAULT SCENARIO toolbar (lower grid): " + buttonName);

                        switch (buttonName)
                        {
                            case "Refresh":
                                btnRefresh_DefaultScenario = item;
                                break;

                            case "Analysis":
                                btnAnalysis_DefaultScenario = item;
                                break;

                            case "Visible fields":
                                btnVisibleFields_DefaultScenario = item;
                                break;
                                
                            default:
                                break;
                        }
                    }
                }
            }



            //Click on ANALYSIS button to open the dropdown menu
            var watch1 = Stopwatch.StartNew();
            executor.ExecuteScript("arguments[0].click();", btnAnalysis_DefaultScenario);
            //Wait till page is reloaded
            watch1.Stop();
            var elapsedMs1 = watch1.ElapsedMilliseconds;
            var res1 = (double)elapsedMs1 / 1000;
            if (res1 > 10)
            {
                logger.Info(string.Format("#Warning It took quite a long time: {0} sec for ANALYSIS dropdown menu to open in the lower grid of scenario in DEFAULT SCENARIO tab!", res1.ToString()));
            }

            Thread.Sleep(1000);


            //Click on WORKSHEET "Germany" item in the ANALYSIS dropdown menu on OVERVIEW CARRIERS tab
            executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//div[contains(text(), 'Germany')]")));

            explicitWaitsUntilElementLocated(15, "//div[@id='visibleFields']", "DEFAULT SCENARIO tab -> Lower Grid -> Toolbar update after selecting WORKSHEET");
            Thread.Sleep(1000);


            //Click on the Refresh button on the Default Scenario tab toolbar in the lower grid i.e. WORKSHEET - TOTAL_SUM
            executor.ExecuteScript("arguments[0].click();", btnRefresh_DefaultScenario);

            //Wait till the WORKSHEET - TOTAL SUM table is loaded in the lower grid on the "Default Scenario" tab
            explicitWaitsUntilElementLocated(15, "//div[@id='ScenarioTablePanel-body']/div[@id='ScenarioTablePanel-innerCt']/div[@id='ScenarioTablePanel-targetEl']/div[2]/div[2]/div/table/tbody/tr[11]", "DEFAULT SCENARIO tab -> Lower Grid -> 'WORKSHEET' -> 'Total SUM'");

            Thread.Sleep(1000);

           
            /*
            //Check that the table cells do not have "Not allocated" inscription
            try
            {
                int NumberOfNoAllocationRecord = 0;

                IList<IWebElement> lowerGrid_table_rows = driver.FindElements(By.XPath("//div[@id='ScenarioTablePanel-body']/div[@id='ScenarioTablePanel-innerCt']/div[@id='ScenarioTablePanel-targetEl']/div[2]/div[2]/div/table/tbody/descendant::tr"));

                int RowIndex = 1;

                //Loop the table's rows
                foreach (IWebElement item in lowerGrid_table_rows)
                {

                    //Retrieve all columns from the row
                    IList<IWebElement> TotalColumnCount = item.FindElements(By.XPath("td"));

                    int ColumnIndex = 1;

                    //Loop the columns of a row
                    foreach (IWebElement colElement in TotalColumnCount)
                    {

                        //Read each cell's text
                        String optionText = colElement.GetAttribute("class");
                        Console.WriteLine ("Lower Grid TR_TEXT: " + optionText);

                       if (optionText.Equals("price_field red-highlighted-row default-border"))
                        {
                            NumberOfNoAllocationRecord++;
                            logger.Error("NO ALLOCATION is displayed in the lower grid of scenario in DEFAULT SCENARIO tab! Row " + RowIndex +", Column " + ColumnIndex + "!");
                        }


                        //Next column
                        ColumnIndex = ColumnIndex + 1;

                       Thread.Sleep(500);

                    }

                    //Next row
                    RowIndex = RowIndex + 1;
                }
                
                Thread.Sleep(500);

                if (NumberOfNoAllocationRecord == 0)
                {
                    logger.Info("All cells in the lower grid of scenario in DEFAULT SCENARIO tab were ALLOCATED SUCCESSFULLY!");
                }

            }
            catch (NoSuchElementException e)
            {
                logger.Error("No such element - Error while detecting rows and column in the lower grid scenario on the DEFAULT SCENARIO Tab: " + e.Message);
            }
            */
            

            driver.SwitchTo().DefaultContent();


            //Take screenshot of "Default Scenario" tab (i.e. WORKSHEET -> TOTAL_SUM view in the lower grid)
            TakeScreenshotOfWebElement("//iframe[contains(@src,'/TenderShipper/TenderShipperView')]", "actual_shipper_DefaultScenario_LowerGrid_Worksheet_TotalSum.png");

                                       

            //Compare master and actual screenshots and create a separate screenshot with differences
            CompareScreenshots2("master_shipper_DefaultScenario_LowerGrid_Worksheet_TotalSum.png", "actual_shipper_DefaultScenario_LowerGrid_Worksheet_TotalSum.png", "difference_shipper_DefaultScenario_LowerGrid_Worksheet_TotalSum.png", 10);


        }



        private void TestAwardingProcess() {

            Actions action = new Actions(driver);
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

            driver.SwitchTo().DefaultContent();
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[contains(@src,'/TenderShipper/TenderShipperView')]")));
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[contains(@src,'/Analysis/ScenarioResultsTab')]")));


            //Click on "Awarding" button
            executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//button[@id='awardingScenario-btnEl']")));

            driver.SwitchTo().DefaultContent();



            /////////////////////////////////////////
            // AWARDING SCENARIO Wizard - STEP#1
            /////////////////////////////////////////

            explicitWaitsUntilElementLocated(15, "//div[@id='AwardingAllocationsTreePanel-body']/div[@class='x-grid-view x-fit-item x-grid-view-default x-unselectable']/table/tbody/tr[7]/td[2]/div[contains(text(), 'CCX DEMO Carrier 04(Lee Brant)')]", "AWARDING SCENARIO wizard -> STEP #1");
            Thread.Sleep(1000);

            //Take screenshot of "Awarding Scenario" wizard STEP#1
            TakeScreenshotOfWebElement("//div[@class='x-window x-layer x-window-default x-closable x-window-closable x-window-default-closable']", "actual_shipper_AwardingScenario_Step1.png");
            Thread.Sleep(1000);

            //Compare master and actual screenshots and create a separate screenshot with differences
            CompareScreenshots2("master_shipper_AwardingScenario_Step1.png", "actual_shipper_AwardingScenario_Step1.png", "difference_shipper_AwardingScenario_Step1.png", 10);
            Thread.Sleep(1000);

            /*
            //Check whether the awarding has already been done for the Default Scenario
            try
            {
                int NumberOfSelectedCheckBoxes = 0;

                IList<IWebElement> awardingWizardStep1_table_rows = driver.FindElements(By.XPath("//div[@id='AwardingAllocationsTreePanel-body']/div/table[@class='x-grid-table x-grid-table-resizer']/tbody/descendant::tr"));

                int RowIndex = 1;

                //Loop the table's rows
                foreach (IWebElement item in awardingWizardStep1_table_rows)
                {
                    if (!item.GetAttribute("class").Equals("x-grid-header-row")) //exclude header row from searching
                    {
                        //Retrieve all columns from the row
                        IList<IWebElement> TotalColumnCount = item.FindElements(By.XPath("td"));

                        int ColumnIndex = 1;

                        //Loop the columns of a row
                        foreach (IWebElement colElement in TotalColumnCount)
                        {

                            //Read each cell's text
                            String optionText = colElement.GetAttribute("class");
                            Console.WriteLine("Awarding wizard check-box TR_TEXT: " + optionText);

                            if (optionText.Equals("awarding-grid-row-disabled x-grid-row-checker"))
                            {
                                NumberOfSelectedCheckBoxes++;
                                logger.Error("AWARDING HAS ALREADY BEEN DONE in DEFAULT SCENARIO as one or more carriers are marked as DISABLED on STEP#1!");
                            }


                            //Next column
                            ColumnIndex = ColumnIndex + 1;

                            Thread.Sleep(500);

                        }

                        //Next row
                        RowIndex = RowIndex + 1;
                    }
                }

                Thread.Sleep(500);

                if (NumberOfSelectedCheckBoxes == 0)
                {
                    //Select all check-boxes on Step#1
                    // executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//div[@id='AwardingAllocationsTreePanel-body']/div[@class='x-grid-view x-fit-item x-grid-view-default x-unselectable']/table/tbody/tr[2]/td[1]/div[@class='x-grid-cell-inner ']/div[@class='x-grid-row-checker']")));
                    //executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//div[@id='AwardingAllocationsTreePanel-body']/div/table[@class='x-grid-table x-grid-table-resizer']/tbody/tr[2]/td[1]/div/div")));
                    action.MoveToElement(driver.FindElement(By.XPath("//div[@id='AwardingAllocationsTreePanel-body']/div/table[@class='x-grid-table x-grid-table-resizer']/tbody/tr[2]/td[2]/div[contains(text(), 'TEST_AUTOMATION_Tender_C#')]"))).Click().Build().Perform();
                    Thread.Sleep(2000);
                }

            }
            catch (NoSuchElementException e)
            {
                logger.Error("No such element - Error while detecting rows and column in the AWARDING SCENARIO wizard -> Step#1: " + e.Message);
            }*/


            //Select all check-boxes on Step#1
            action.MoveToElement(driver.FindElement(By.XPath("//div[@id='AwardingAllocationsTreePanel-body']/div/table[@class='x-grid-table x-grid-table-resizer']/tbody/tr[2]/td[2]/div[contains(text(), 'TEST_AUTOMATION_Tender_C#')]"))).Click().Build().Perform();
            Thread.Sleep(2000);



            /////////////////////////////////////////
            // AWARDING SCENARIO Wizard - STEP#2
            /////////////////////////////////////////

            //Click on "Next" button if it is enabled

            IWebElement btnNext = driver.FindElement(By.XPath("//div[@id='nextBtn']"));

            String enabledNextBtn = btnNext.GetAttribute("class");

            if (enabledNextBtn.Equals("x-btn x-box-item x-toolbar-item x-btn-default-small x-noicon x-btn-noicon x-btn-default-small-noicon")) {
                executor.ExecuteScript("arguments[0].click();", btnNext);

                explicitWaitsUntilElementLocated(15, "//iframe[@id='English_Message-iframeEl']", "AWARDING SCENARIO wizard -> STEP #2");
                Thread.Sleep(1000);

                //Take screenshot of "Awarding Scenario" wizard STEP#2
                TakeScreenshotOfWebElement("//div[@class='x-window x-layer x-window-default x-closable x-window-closable x-window-default-closable']", "actual_shipper_AwardingScenario_Step2.png");
                Thread.Sleep(1000);

                //Compare master and actual screenshots and create a separate screenshot with differences
                CompareScreenshots2("master_shipper_AwardingScenario_Step2.png", "actual_shipper_AwardingScenario_Step2.png", "difference_shipper_AwardingScenario_Step2.png", 10);
                Thread.Sleep(1000);

            }
            else
            {
                logger.Error("NEXT button is disabled after selecting all check-boxes on Step#1 of AWARDING SCENARIO wizard.");
                driver.Quit();
            }




            /////////////////////////////////////////
            // AWARDING SCENARIO Wizard - STEP#3
            /////////////////////////////////////////

            //Click on "Next" button
                      
                executor.ExecuteScript("arguments[0].click();", btnNext);

                explicitWaitsUntilElementLocated(15, "//iframe[@id='English_Message-iframeEl']", "AWARDING SCENARIO wizard -> STEP #3");
                Thread.Sleep(1000);

                //Take screenshot of "Awarding Scenario" wizard STEP#3
                TakeScreenshotOfWebElement("//div[@class='x-window x-layer x-window-default x-closable x-window-closable x-window-default-closable']", "actual_shipper_AwardingScenario_Step3.png");
                Thread.Sleep(1000);

                //Compare master and actual screenshots and create a separate screenshot with differences
                CompareScreenshots2("master_shipper_AwardingScenario_Step3.png", "actual_shipper_AwardingScenario_Step3.png", "difference_shipper_AwardingScenario_Step3.png", 10);
                Thread.Sleep(1000);



            /////////////////////////////////////////
            // AWARDING SCENARIO Wizard - STEP#4
            /////////////////////////////////////////

            //Click on "Next" button

            executor.ExecuteScript("arguments[0].click();", btnNext);

            explicitWaitsUntilElementLocated(15, "//iframe[@id='English_Message-iframeEl']", "AWARDING SCENARIO wizard -> STEP #4");
            Thread.Sleep(1000);

            //Take screenshot of "Awarding Scenario" wizard STEP#4
            TakeScreenshotOfWebElement("//div[@class='x-window x-layer x-window-default x-closable x-window-closable x-window-default-closable']", "actual_shipper_AwardingScenario_Step4.png");
            Thread.Sleep(1000);

            //Compare master and actual screenshots and create a separate screenshot with differences
            CompareScreenshots2("master_shipper_AwardingScenario_Step4.png", "actual_shipper_AwardingScenario_Step4.png", "difference_shipper_AwardingScenario_Step4.png", 10);
            Thread.Sleep(1000);



            /////////////////////////////////////////
            // AWARDING SCENARIO Wizard - STEP#5
            /////////////////////////////////////////

            //Click on "Next" button
            executor.ExecuteScript("arguments[0].click();", btnNext);

            explicitWaitsUntilElementLocated(15, "//div[@id='AwardingAllocationsTreePanel-body']/div[@class='x-grid-view x-fit-item x-grid-view-default x-unselectable']/table/tbody/tr[7]/td[2]/div[contains(text(), 'CCX DEMO Carrier 04(Lee Brant)')]", "AWARDING SCENARIO wizard -> STEP #5");
            Thread.Sleep(1000);

            //Take screenshot of "Awarding Scenario" wizard STEP#5
            TakeScreenshotOfWebElement("//div[@class='x-window x-layer x-window-default x-closable x-window-closable x-window-default-closable']", "actual_shipper_AwardingScenario_Step5.png");
            Thread.Sleep(1000);

            //Compare master and actual screenshots and create a separate screenshot with differences
            CompareScreenshots2("master_shipper_AwardingScenario_Step5.png", "actual_shipper_AwardingScenario_Step5.png", "difference_shipper_AwardingScenario_Step5.png", 10);
            Thread.Sleep(1000);

            //Click on all check-boxes 
            action.MoveToElement(driver.FindElement(By.XPath("//div[@id='AwardingAllocationsTreePanel-body']/div[@class='x-grid-view x-fit-item x-grid-view-default x-unselectable']/table/tbody/tr/td/div[contains(text(), 'TEST_AUTOMATION_Tender_C#')]"))).Click().Build().Perform();
            Thread.Sleep(2000);

            /*
            //Click on all check-boxes 
            action.MoveToElement(driver.FindElement(By.XPath("//div[@id='AwardingAllocationsTreePanel-body']/div[@class='x-grid-view x-fit-item x-grid-view-default x-unselectable']/table/tbody/tr/td/div[contains(text(), 'TEST_AUTOMATION_Tender_C#')]"))).Click().Build().Perform();
            Thread.Sleep(4000);

            //Click on a check-box against allocated carrier
            action.MoveToElement(driver.FindElement(By.XPath("//div[@id='AwardingAllocationsTreePanel-body']/div[@class='x-grid-view x-fit-item x-grid-view-default x-unselectable']/table/tbody/tr/td/div[contains(text(), 'CCX DEMO Carrier 05')]"))).Click().Build().Perform();
            Thread.Sleep(4000);*/


            /*
            //Check whether the "Thumb Up" button is enabled
            if (driver.FindElement(By.XPath("//div[@id='AwardingScenarioFormPanel-targetEl']/div[@class='x-container x-box-item x-container-default x-box-layout-ct']/div/div/div[1]/em/button")).Enabled)
            {
                Console.WriteLine("THUMB UP button is enabled on last step of Awarding wizard.");

                //Check whether the "To Next Round" button is enabled
                if (driver.FindElement(By.XPath("//div[@id='AwardingScenarioFormPanel-targetEl']/div[@class='x-container x-box-item x-container-default x-box-layout-ct']/div/div/div[2]/em/button")).Enabled)
                {
                    Console.WriteLine("TO NEXT ROUND button is enabled on last step of Awarding wizard.");*/

                    //Check whether the "Settings" button is enabled
                    if (driver.FindElement(By.XPath("//div[@id='AwardingScenarioFormPanel-targetEl']/div[@class='x-container x-box-item x-container-default x-box-layout-ct']/div/div/div[3]/em/button")).Enabled)
                    {
                        Console.WriteLine("SETTINGS button is enabled on last step of Awarding wizard.");

                        //Check whether the "Move carriers to next round including submitted prices" check-box is enabled
                        if (driver.FindElement(By.XPath("//div[@id='AwardingScenarioFormPanel-targetEl']/table[@class='x-field x-form-item x-box-item x-field-default x-vbox-form-item']/tbody/tr/td[@class='x-form-item-body x-form-cb-wrap']/input[@class='x-form-field x-form-checkbox']")).Enabled)
                        {
                            Console.WriteLine("MOVE CARRIERS TO NEXT ROUND check-box is enabled on last step of Awarding wizard.");

                            //Click on the "Send" button
                            executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//button[@id='finishBtn-btnEl']/span[contains(text(), 'Send')]")));

                            driver.SwitchTo().DefaultContent();
                           

                            //Wait till the AWARDING SCENARIO wizard gets closed and DEFAULT SCENARIO tab is displayed again
                            explicitWaitsUntilElementLocated(15, "//iframe[contains(@src,'/TenderShipper/TenderShipperView/')]", "DEFAULT SCENARIO Tab -> after clicking SEND on Awarding Scenario Wizard");
                            //Thread.Sleep(10000);



                            /////////////////////////////////////////
                            // AWARDING SCENARIO Wizard - STEP#1 with sent results
                            /////////////////////////////////////////

                            int count = 1;

                            try
                            {
                        do
                        {

                            driver.SwitchTo().DefaultContent();
                            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[contains(@src,'/TenderShipper/TenderShipperView/')]")));
                            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[contains(@src,'/Analysis/ScenarioResultsTab')]")));

                            Thread.Sleep(10000);

                            //Click on "Awarding" button
                            executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//button[@id='awardingScenario-btnEl']")));

                            driver.SwitchTo().DefaultContent();

                            // explicitWaitsUntilElementLocated(15, "//div[@id='AwardingAllocationsTreePanel-body']/div[@class='x-grid-view x-fit-item x-grid-view-default x-unselectable']/table/tbody/tr[7]/td[2]/div[contains(text(), 'CCX DEMO Carrier 04(Lee Brant)')]", "AWARDING SCENARIO wizard -> STEP #1 with sent awardings");
                            //Thread.Sleep(2000);

                            IList<IWebElement> sentZip = driver.FindElements(By.XPath("//div[@id='AwardingAllocationsTreePanel-body']/div[@class='x-grid-view x-fit-item x-grid-view-default x-unselectable']/table/tbody/tr[5]/td[6]/div/descendant::*"));

                            if (sentZip.Count == 0)
                            {

                                //Click 'Close' button to close AWARDING SCENARIO wizard form
                                executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//button[@id='closeBtn-btnEl']")));
                                Thread.Sleep(10000);
                                count++;

                            }
                            else
                            {
                                foreach (IWebElement item in sentZip)
                                {
                                    if (item.Text.Equals("Zip"))
                                    {

                                        //Take screenshot of "Awarding Scenario" wizard STEP#1 with sent awarding results
                                        TakeScreenshotOfWebElement("//div[@class='x-window x-layer x-window-default x-closable x-window-closable x-window-default-closable']", "actual_shipper_AwardingScenario_Step1_WithSentResults.png");
                                        Thread.Sleep(1000);

                                        //Compare master and actual screenshots and create a separate screenshot with differences
                                        CompareScreenshots2("master_shipper_AwardingScenario_Step1_WithSentResults.png", "actual_shipper_AwardingScenario_Step1_WithSentResults.png", "difference_shipper_AwardingScenario_Step1_WithSentResults.png", 10);
                                        Thread.Sleep(1000);


                                        //Click 'Close' button to close AWARDING SCENARIO wizard form
                                        executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//button[@id='closeBtn-btnEl']")));
                                        Thread.Sleep(1000);


                                        logger.Info("ZIP link was detected on Step#1 of AWARDING SCENARIO wizard. Awarding results have been successfully sent.");


                                    }
                                }
                                break;
                            }
                        } while (count < 5);



                            }
                            catch (Exception e)
                            {
                                logger.Warn("Unable to locate ZIP link with awarding results for the awarded carrier on STEP#1 of AWARDING SCENARIO Wizard: " + e.Message);

                            }

                        }
                        else
                        {
                            logger.Warn("MOVE CARRIERS TO THE NEXT ROUND check-box is DISABLED on STEP#5 of AWARDING SCENARIO Wizard!");
                        }
                    }
                    else
                    {
                        logger.Warn("SETTINGS button is DISABLED on STEP#5 of AWARDING SCENARIO Wizard!");
                    }

              /*  }
                else
                {
                    logger.Warn("TO NEXT ROUND button is DISABLED on STEP#5 of AWARDING SCENARIO Wizard!");
                }

            }
            else {
                logger.Warn("THUMB UP button is DISABLED on STEP#5 of AWARDING SCENARIO Wizard!");
            }*/

        }


        private void FindAndApprovePublishedTender()
        {
            // use js executor as click have problem in IE
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

            driver.SwitchTo().DefaultContent();

            //When using an iframe, you will first have to switch to the iframe, before selecting the elements of that iframe.
            //driver.SwitchTo ( ).Frame ("mmCtl13_IFrame");
            driver.SwitchTo().Frame(0);

            //Click on "Filter Your Search" button
            var btnFilter = driver.FindElement(By.XPath("//*[@id='filterButton-btnEl']"));
            executor.ExecuteScript("arguments[0].click();", btnFilter);

            Thread.Sleep(2000);

            //Enter tender's Reference number into search field
            var txtFilterTenderRefNum = driver.FindElement(By.XPath("//*[@id='filterRef-inputEl']"));
            txtFilterTenderRefNum.SendKeys(globalTenderRefNum);  //Tender Reference Number

            Thread.Sleep(1000);

            //Click on "Apply" button to search the tender with the requested title
            var btnFilterApply = driver.FindElement(By.XPath("//*[@id='button-1048-btnEl']"));
            executor.ExecuteScript("arguments[0].click();", btnFilterApply);

            //Wait till the search tender is displayed in the grid 
            waitTillDescendentElementsAvailable(10, "//div[@id='ShipperGridPanel-body']/div/table/tbody/descendant::tr", "class", "x-grid-row ", "Search Results - PENDING TENDERS tab ADMIN");

            Thread.Sleep(1000);

            //Get the tender's refernce value from the "Reference" column
            //globalTenderRefNum = driver.FindElement(By.XPath("//div[@id='ShipperGridPanel-body']/div[@class='x-grid-view x-fit-item x-grid-view-default x-unselectable']/table/tbody/tr[2]/td/div[@class='x-grid-rowwrap-div']/table/tbody/tr/td[2]/div")).Text;

            //Console.WriteLine("Tender REF# is: " + globalTenderRefNum);

            // driver.FindElement(By.XPath("//*[@id='gridview-1039']/table/tbody/tr[2]/td/div/table/tbody/tr/td[14]/div/div/div[2]")).Click();

            /*
            var txtFilterTenderRef = driver.FindElement(By.XPath("//*[@id='filterRef-inputEl']"));
            txtFilterTenderRef.SendKeys(tenderRef);
            System.Threading.Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@id='button-1037-btnInnerEl']")).Click();

            System.Threading.Thread.Sleep(3000);*/

            //Click on tender's "Approve" button
            var btnTenderApprove = driver.FindElement(By.XPath("//div[@id='ShipperGridPanel-body']/div/table/tbody/tr[2]/td/div/table/tbody/tr/td[14]/div/div/div/div/div[5]"));
            executor.ExecuteScript("arguments[0].click();", btnTenderApprove);
            //driver.FindElement(By.XPath("//*[@id='gridview-1039']/table/tbody/tr[2]/td/div/table/tbody/tr/td[14]/div/div/div[2]")).Click();


            Thread.Sleep(1000);

            driver.SwitchTo().DefaultContent();

            //Click on "Accept" button on the "Approve Tender" form
            var btnApproveTender = driver.FindElement(By.XPath("//div[6]/div[3]/div/div/div"));
            executor.ExecuteScript("arguments[0].click();", btnApproveTender);

            System.Threading.Thread.Sleep(5000);
        }


        private void FindAndAcceptPublishedTender(string username)
        {
            // use js executor as click have problem in IE
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

            driver.SwitchTo().DefaultContent();

            //When using an iframe, you will first have to switch to the iframe, before selecting the elements of that iframe.
            //driver.SwitchTo ( ).Frame ("mmCtl13_IFrame");
            driver.SwitchTo().Frame("mmCtl13_IFrame");

            //Click on "Filter Your Search" button
            var btnFilter = driver.FindElement(By.XPath("//*[@id='filterButton-btnEl']"));
            executor.ExecuteScript("arguments[0].click();", btnFilter);

            Thread.Sleep(2000);

            //Enter tender's Reference number into search field
            var txtFilterTenderRefNum = driver.FindElement(By.XPath("//*[@id='filterRef-inputEl']"));
            txtFilterTenderRefNum.SendKeys(globalTenderRefNum);  //Tender Reference Number
            //txtFilterTenderRefNum.SendKeys("T1711100916");

            System.Threading.Thread.Sleep(1000);

            //Click on "Apply" button to search the tender with the requested title
            var btnFilterApply = driver.FindElement(By.XPath("//*[@id='button-1100-btnEl']"));
            var watch0 = System.Diagnostics.Stopwatch.StartNew();
            executor.ExecuteScript("arguments[0].click();", btnFilterApply);

            //Wait till page is reloaded
            watch0.Stop();
            var elapsedMs0 = watch0.ElapsedMilliseconds;
            var res0 = (double)elapsedMs0 / 1000;
            if (res0 > 10)
            {
                logger.Info(string.Format("#Warning '{0}' took quite a long time: {1} sec for carrier - " + username + "!", "Reload All Tenders (carrier) tab tab after clicking on 'Apply Filter' button", res0.ToString()));
            }

            System.Threading.Thread.Sleep(1000);


            driver.SwitchTo().DefaultContent();


            //Waiting till the Carriers's main window is re-loaded after searching the required tender 
            //explicitWaitsUntilElementLocated(20, "//iframe[@name='mmCtl13_IFrame']", "ALL TENDERS (carrier) TAB with filtered tender");
            explicitWaitsUntilElementLocated(20, "//iframe[contains(@src,'/TenderList/CarrierGridView')]", "ALL TENDERS (carrier) TAB with filtered tender");


            //When using an iframe, you will first have to switch to the iframe, before selecting the elements of that iframe.
            //driver.SwitchTo().Frame("mmCtl13_IFrame");
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[contains(@src,'/TenderList/CarrierGridView')]")));


            //Waiting till the 'All tenders' grid is downloaded in the Carrier's main window
            explicitWaitsUntilElementLocated(20, "//*[@class='row-imagecommand   icon-note ']", "CARRIER's GRID with filtered tender");


            //Click on tender's "View this tender Info" button
            var btnTenderApprove = driver.FindElement(By.XPath("//div[@id='CarrierGridPanel-body']/div/table/tbody/tr[2]/td/div/table/tbody/tr/td[20]/div/div/div[1]"));
            var watch01 = System.Diagnostics.Stopwatch.StartNew();
            executor.ExecuteScript("arguments[0].click();", btnTenderApprove);

            //Wait till page is reloaded
            watch01.Stop();
            var elapsedMs01 = watch01.ElapsedMilliseconds;
            var res01 = (double)elapsedMs01 / 1000;
            if (res01 > 10)
            {
                logger.Info(string.Format("#Warning '{0}' took quite a long time: {1} sec for carrier - " + username + "!", "Opening VIEW TENDER INFO Tab", res01.ToString()));
            }

            Thread.Sleep(1000);

            //Switching to subframe
            driver.SwitchTo().DefaultContent();
            driver.SwitchTo().Frame(1);
            System.Threading.Thread.Sleep(2000);
            driver.SwitchTo().Frame(0);

            //Check if "Interested" button is displayed
            if (driver.FindElement(By.XPath("//div[@id='StatusButtonsPanel']")).GetAttribute("style") != "margin: 10px; display: none;")
            {

                //Wait till "Interested" button is displayed on "Tender Info" tab
                var btnInterested = driver.FindElement(By.XPath("//button[@id='BtnIniterest-btnEl']"));
                explicitWaitsUntilElementLocated(15, "//button[@id='BtnIniterest-btnEl']", "Tender Info Tab");


                //Click on "Interested" button 
                executor.ExecuteScript("arguments[0].click();", btnInterested);

                Thread.Sleep(500);

                //Click "Yes" on a dialog to confirm
                driver.SwitchTo().DefaultContent();
                driver.SwitchTo().Frame(1);
                //var btnYes = driver.FindElement(By.XPath("//div[@id='messagebox-1001']/div[3]/div/div/div/em/button"));
                var btnYes = driver.FindElement(By.XPath("//div[@id='messagebox-1001']/descendant::span[text()='Yes']"));

                var watch1 = System.Diagnostics.Stopwatch.StartNew();
                executor.ExecuteScript("arguments[0].click();", btnYes);

                //Wait till page is reloaded
                watch1.Stop();
                var elapsedMs1 = watch1.ElapsedMilliseconds;
                var res1 = (double)elapsedMs1 / 1000;
                if (res1 > 10)
                {
                    logger.Info(string.Format("#Warning '{0}' took quite a long time: {1} sec for carrier - " + username + "!", "Reload Tender Info tab after clicking on Interested/Yes buttons", res1.ToString()));
                }

            }


            System.Threading.Thread.Sleep(1000);

        }

        private void CheckAvailableTenderParts(string username)
        {

            driver.SwitchTo().DefaultContent();
            driver.SwitchTo().Frame(1);

            // use js executor as click have problem in IE
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

            //Check which tender parts are available in TENDER INFO - NAVIGATION panel
            IList<IWebElement> available_TenderParts = driver.FindElements(By.XPath("//div[@id='TenderStructurePanel-body']/div/table/tbody/descendant::tr"));

            int RowIndex = 1;

            //Loop the tender's parts
            foreach (IWebElement item in available_TenderParts)
            {

                IList<IWebElement> TotalColumnCount = item.FindElements(By.XPath("td"));

                int ColumnIndex = 1;


                foreach (IWebElement colElement in TotalColumnCount)
                {

                    //Retrieve names of available tender parts
                    String tenderPartName = colElement.FindElement(By.XPath("div")).Text;
                    //Console.WriteLine("Tender part: " + tenderPartName);

                    switch (tenderPartName)
                    {

                        case "Information":
                            tenderPart_Information = true;
                            enabledInformation = item.GetAttribute("class").ToString();
                            Console.WriteLine("Information part: " + enabledInformation);
                            logger.Info("INFORMATION item is avaialbale in 'Navigation' panel for carrier - " + username + ".");
                            break;
                        case "Destinations":
                            tenderPart_Destinations = true;
                            enabledDestinations = item.GetAttribute("class").ToString();
                            Console.WriteLine("Destinations part: " + enabledDestinations);
                            logger.Info("DESTINATIONS item is avaialbale in 'Navigation' panel for carrier - " + username + ".");
                            break;
                        case "Terms & Conditions":
                            tenderPart_TermsAndConditions = true;
                            enabledTermsAndConditiops = item.GetAttribute("class").ToString();
                            Console.WriteLine("Terms & Conditions part: " + enabledTermsAndConditiops);
                            termsAndConditions = colElement;
                            logger.Info("TERMS & CONDITIONS item is avaialbale in 'Navigation' panel for carrier - " + username + ".");
                            break;
                        case "Bidding Matrix":
                            tenderPart_BiddingMatrix = true;
                            enabledBiddingMatrix = item.GetAttribute("class").ToString();
                            Console.WriteLine("Bidding Matrix part: " + enabledBiddingMatrix);
                            biddingMatrix = colElement;
                            logger.Info("BIDDING MATRIX item is avaialbale in 'Navigation' panel for carrier - " + username + ".");
                            break;
                        case "Uploads & Comments":
                            tenderPart_UploadsAndComments = true;
                            enabledUploadsAndComments = item.GetAttribute("class").ToString();
                            Console.WriteLine("Uploads & Comments part: " + enabledUploadsAndComments);
                            logger.Info("UPLOADS & COMMENTS item is avaialbale in 'Navigation' panel for carrier - " + username + ".");
                            break;
                        case "Questions & Answers":
                            tenderPart_QuestionsAndAnswers = true;
                            enabledQuestionsAndAnswers = item.GetAttribute("class").ToString();
                            Console.WriteLine("Questions & Answers part: " + enabledQuestionsAndAnswers);
                            logger.Info("QUESTIONS & ANSWERS item is avaialbale in 'Navigation' panel for carrier - " + username + ".");
                            break;

                        default:
                            break;
                    }
                    //Next column
                    ColumnIndex = ColumnIndex + 1;
                }
                //Next row
                RowIndex = RowIndex + 1;
            }


        }

        private void AcceptTermsAndConditions(string username)
        {
            driver.SwitchTo().DefaultContent();
            driver.SwitchTo().Frame(1);

            // use js executor as click have problem in IE
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

            if (tenderPart_TermsAndConditions == true && enabledTermsAndConditiops.Equals("x-grid-row   x-grid-tree-node-leaf"))
            {
                var watch2 = System.Diagnostics.Stopwatch.StartNew();

                //Click on "Terms & Conditions" item  
                executor.ExecuteScript("arguments[0].click();", termsAndConditions);

                //Switch to "Terms & Conditions" tab
                driver.SwitchTo().Frame("tabTenderTermsConditions_IFrame");

                while (!driver.FindElement(By.XPath("//div[@id='DescriptionPanel-body']/label[@id='ConfidentialyLabel']/span/b[contains(text(), 'Confidentiality agreement:')]")).Displayed)
                {
                    System.Threading.Thread.Sleep(200);
                }

                watch2.Stop();
                var elapsedMs2 = watch2.ElapsedMilliseconds;
                var res2 = (double)elapsedMs2 / 1000;

                logger.Info("TERMS & CONDITIONS Tab was loading during " + res2 + "seconds for carrier - " + username + ".");

                if (res2 > 10)
                {
                    logger.Warn(string.Format("#Warning '{0}' took quite a long time: {1} sec for carrier - " + username + "!", "TERMS & CONDITIONS Tab", res2.ToString()));
                }


                System.Threading.Thread.Sleep(500);

                //Check if "Submit" button is displayed
                if (driver.FindElement(By.XPath("//fieldset[@id='BasicInformationSet']/div[@id='BasicInformationSet-body']/div[@id='DescriptionPanel']/div[@id='DescriptionPanel-body']/div[@id='ConfidentionalSubmit']/em[@id='ConfidentionalSubmit-btnWrap']/button[@id='ConfidentionalSubmit-btnEl']")).Displayed)
                {

                    //Select "Hereby I do confirm that I read and accept the confidentiality agreement" check-box
                    executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//fieldset[@id='BasicInformationSet']/div[@id='BasicInformationSet-body']/div[@id='DescriptionPanel']/div[@id='DescriptionPanel-body']/table[@id='AcceptCheckboxBox']/tbody/tr[@id='AcceptCheckboxBox-inputRow']/td[@id='AcceptCheckboxBox-bodyEl']/input[@id='AcceptCheckboxBox-inputEl']")));

                    System.Threading.Thread.Sleep(500);

                    var watch3 = System.Diagnostics.Stopwatch.StartNew();

                    //Click on "Submit" button
                    executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//fieldset[@id='BasicInformationSet']/div[@id='BasicInformationSet-body']/div[@id='DescriptionPanel']/div[@id='DescriptionPanel-body']/div[@id='ConfidentionalSubmit']/em[@id='ConfidentionalSubmit-btnWrap']/button[@id='ConfidentionalSubmit-btnEl']")));

                    //Wait till TERMS AND CONDITIONS tab is loaded
                    while (!driver.FindElement(By.XPath("//div[@id='DescriptionPanel-body']/label[@id='AgreementAcceptedInfoLabel']/img")).Displayed)
                    {
                        System.Threading.Thread.Sleep(200);
                    }

                    watch3.Stop();
                    var elapsedMs3 = watch3.ElapsedMilliseconds;
                    var res3 = (double)elapsedMs3 / 1000;

                    logger.Info("Confidential Agreement was submitted during " + res3 + "seconds for carrier - " + username + ".");

                    if (res3 > 10)
                    {
                        logger.Warn(string.Format("#Warning '{0}' took quite a long time: {1} sec for carrier - " + username + "!", "Reload Tender Info tab after clicking on Interested/Yes buttons", res3.ToString()));
                    }

                    System.Threading.Thread.Sleep(500);

                }
                else
                {
                    if (driver.FindElement(By.XPath("//div[@id='DescriptionPanel-body']/label[@id='AgreementAcceptedInfoLabel']/img")).Displayed)
                    {

                        logger.Info("Confidential Agreeement was already submitted on TERMS & CONDITIONS tab for carrier - " + username + ".");
                    }
                    else
                    {
                        logger.Error("Unable to find 'Submit' button for Confidential Agreeement on TERMS & CONDITIONS tab for carrier - " + username + ". Also, the Confidential Agreement does not look to have been already submitted.");
                    }
                }

            }
            else
            {
                logger.Error("Unable to click on TERMS & CONDITIONS item for carrier - " + username + " - it is either not available or in disabled status.");
            }
        }



        private void OpenBiddingMatrixAndSubmitPrices(string username, string matrixFilelocation)
        {
            Actions action = new Actions(driver);
            driver.SwitchTo().DefaultContent();
            driver.SwitchTo().Frame(1);

            // use js executor as click have problem in IE
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            

            //Check which tender parts are available in TENDER INFO - NAVIGATION panel
            IList<IWebElement> available_TenderParts = driver.FindElements(By.XPath("//div[@id='TenderStructurePanel-body']/div/table/tbody/descendant::tr"));

            int RowIndex = 1;

            //Loop the tender's parts
            foreach (IWebElement item in available_TenderParts)
            {

                IList<IWebElement> TotalColumnCount = item.FindElements(By.XPath("td"));

                int ColumnIndex = 1;


                foreach (IWebElement colElement in TotalColumnCount)
                {

                    //Retrieve names of available tender parts
                    String tenderPartName = colElement.FindElement(By.XPath("div")).Text;
                    //Console.WriteLine("Tender part: " + tenderPartName);

                    switch (tenderPartName)
                    {
                        case "Bidding Matrix":
                            enabledBiddingMatrix = item.GetAttribute("class").ToString();
                            Console.WriteLine("Bidding Matrix class after accepting T&Cs: " + enabledBiddingMatrix);
                            biddingMatrix = colElement;
                            break;


                        default:
                            break;
                    }
                    //Next column
                    ColumnIndex = ColumnIndex + 1;
                }
                //Next row
                RowIndex = RowIndex + 1;
            }



            if (tenderPart_BiddingMatrix == true && enabledBiddingMatrix.Equals("x-grid-row   x-grid-tree-node-leaf"))
            {                
                var watch = System.Diagnostics.Stopwatch.StartNew();

                //Click on "Bidding Matrix" item  
                executor.ExecuteScript("arguments[0].click();", biddingMatrix);

                //Switch to "Bidding Matrix" tab
                //driver.SwitchTo().Frame("tabBiddingMatrix_IFrame");
                driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[contains(@src,'/TenderCarrier/BiddingMatrixTab')]")));


                while (!driver.FindElement(By.XPath("//div[@id='silverlightControlHost']")).Displayed)
                {
                    Thread.Sleep(200);
                }

                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;
                var res = (double)elapsedMs / 1000;

                logger.Info("BIDDING MATRIX Tab was loading during " + res + "seconds for carrier - " + username + ".");

                if (res > 10)
                {
                    logger.Warn(string.Format("#Warning '{0}' took quite a long time: {1} sec for carrier - " + username + "!", "BIDDING MATRIX Tab", res.ToString()));
                }

                //Thread.Sleep(3000);

                driver.SwitchTo().DefaultContent();
                driver.SwitchTo().Frame(1);

                //Thread.Sleep(3000);

                //Take screenshot of "Bidding Matrix" tab
                TakeScreenshotOfWebElement("//div[@id='TabPanel']", "actual_carrier_" + username + "_bidding_matrix.png");

                //Compare master and actual screenshots and create a separate screenshot with differences
                //CompareScreenshots("master_carrier_bidding_matrix.png", "actual_carrier_" + username + "_bidding_matrix.png", "difference_carrier_" + username + "_bidding_matrix.png");
                //CompareScreenshots2("master_carrier_bidding_matrix.png", "actual_carrier_" + username + "_bidding_matrix.png", "difference_carrier_" + username + "_bidding_matrix.png", 40);
                //CompareScreenshotsMatrix("master_carrier_bidding_matrix.png", "actual_carrier_" + username + "_bidding_matrix.png", "difference_carrier_" + username + "_bidding_matrix.png", 40);



                var watch15 = System.Diagnostics.Stopwatch.StartNew();

                while (CompareScreenshotsMatrix("master_carrier_bidding_matrix.png", "actual_carrier_" + username + "_bidding_matrix.png", 40)>25)
                {
                    //wait next 3 seconds
                    Thread.Sleep(1500);

                    //Delete existing "actual_carrier_" + username + "_bidding_matrix.png" screenshot
                    
                    DeleteScreenshot("actual_carrier_" + username + "_bidding_matrix.png");

                    //Create new "actual_carrier_" + username + "_bidding_matrix.png" screenshot
                    TakeScreenshotOfWebElement("//div[@id='TabPanel']", "actual_carrier_" + username + "_bidding_matrix.png");
                }

                watch15.Stop();
                var elapsedMs15 = watch15.ElapsedMilliseconds;
                var res15 = (double)elapsedMs15 / 1000;

                logger.Info("BIDDING MATRIX was loading during " + res15 + "seconds for carrier - " + username + ".");

                if (res15 > 25)
                {
                    logger.Warn(string.Format("#Warning '{0}' took quite a long time: {1} sec for carrier - " + username + "!", "BIDDING MATRIX", res15.ToString()));
                }


                //////////////////////
                //Click on the web-element based on screen's X and Y coordinates
                /* driver.SwitchTo().DefaultContent();

                 int xScrollPosition = 662; //enter your x co-ordinate  655
                 int yScrollPosition = 102; //enter your y co-ordinate 105

                 IWebElement element = driver.FindElement(By.XPath("//body[@id='ext-gen1018']"));
                 executor.ExecuteScript("window.scroll(" + xScrollPosition + ", " + yScrollPosition + ");");
                 executor.ExecuteScript("arguments[0].click();", element);

                 action.MoveToElement(element, xScrollPosition, yScrollPosition).Click().Build().Perform();
                 */

                Thread.Sleep(2000);

                driver.SwitchTo().DefaultContent();
                driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[contains(@src,'/TenderCarrier/TenderCarrierView')]")));
               

                //Import carrier's prices from CMX binary file   
                // executor.ExecuteScript("objShippingMatrix.Content.ShippingMatrixClient.ImportTestMatrix('D:/ccx3/Storage/Default.ccx');");
                executor.ExecuteScript("objCarrierBiddingMatrix.Content.CarrierMatrixClient.ImportTestMatrix('"+ matrixFilelocation + "');");
                Thread.Sleep(5000);

                 //Save carrier's prices
                 executor.ExecuteScript("objCarrierBiddingMatrix.Content.CarrierMatrixClient.SaveMatrix();");
                 Thread.Sleep(5000);

                 //Submit carrier's prices                
                 executor.ExecuteScript("objCarrierBiddingMatrix.Content.CarrierMatrixClient.SubmitMatrix();");
                 Thread.Sleep(5000);
                


                driver.SwitchTo().DefaultContent();
                driver.SwitchTo().Frame(1);
                
                //Wait till prices are submitted and the statuses are updated in the "Status: Bidding Phase" panel
                var watch01 = Stopwatch.StartNew();
                int timer = 0;

                while (driver.FindElement(By.XPath("//label[@id='ProcessStatusFlag']/img")).GetAttribute("class").Equals("x-label-icon icon-flagyellow"))
                {
                    Thread.Sleep(1000);
                    timer++;
                    if (timer == 15) {
                        logger.Error(string.Format("'{0}' took quite a long time: {1} sec for carrier - " + username + "!", "Submitting prices into the BIDDING MATRIX", timer.ToString()));
                        driver.Quit();
                    }
                }

                watch01.Stop();
                var elapsedMs01 = watch01.ElapsedMilliseconds;
                var res01 = (double)elapsedMs01 / 1000;

                logger.Info("Prices have been submitted into the BIDDING MATRIX during " + res01 + "seconds for carrier - " + username + ".");
                                
                Thread.Sleep(500);
                
                //Verify statuses in the "Status: Bidding Phase" panel
                var processFlag = driver.FindElement(By.XPath("//label[@id='BidsSubmittedIcon']/img"));
                string submitStatus = processFlag.GetAttribute("class").ToString();

                Console.WriteLine("Submit status is " + submitStatus.ToUpper());

                if (submitStatus.Equals("x-label-icon icon-bulletcross")) {

                    logger.Error("STATUS PANEL shows that offers have not been submitted for carrier " + username);
                    driver.Quit();

                }


            }
            else
            {
                logger.Error("Unable to click on BIDDING MATRIX item - it is either not available or in disabled status.");
            }
        }



        private void CloseUserProfileForm(string username)
        {
            driver.SwitchTo().DefaultContent();
            Actions action = new Actions(driver);
            Boolean userProfile = false;
            Boolean profileStatus = false;

            // use js executor as click have problem in IE
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

            System.Threading.Thread.Sleep(5000);

            //Check whether the "User Profile" form and the "Profile Status" popup are open after login
            IList<IWebElement> divParts = driver.FindElements(By.XPath("//body/div"));
                      

                //Loop the div parts
                foreach (IWebElement item in divParts)
                {

                    //Retrieve div's class name
                    String divClassName = item.GetAttribute("class");
                    Console.WriteLine("Div Class Name: " + divClassName);

                    switch (divClassName)
                    {

                    //"Profile Status" popup
                    case "x-window x-notification x-layer x-window-default x-closable x-window-closable x-window-default-closable":
                        try
                        {
                            profileStatus = true;      

                        }
                        catch (NoSuchElementException e)
                        {
                            logger.Error("Unable to click on 'X' button on the PROFILE STATUS popup for carrier - " + username + ". " + e.Message);
                        }
                        break;



                    //"User Profile" form
                    case "x-window x-layer x-window-default x-closable x-window-closable x-window-default-closable":
                            try
                            {

                            userProfile = true;

                            }
                            catch (NoSuchElementException e)
                            {
                                logger.Error("Unable to click on 'CLOSE' button on the USER PROFILE form for carrier - " + username + ". " + e.Message);
                            }
                            break;  
                     
                                                                
                        
                        default:
                            break;
                    }
                }


            //Close the "User Profile" form and the "Profile Status" popup
                if (profileStatus == true && userProfile == true)  {

                //Click on "Close" button on the "User Profile Form"
                try
                {
                    var userProfileCloseBtn = driver.FindElement(By.XPath("//body/div[@class='x-window x-layer x-window-default x-closable x-window-closable x-window-default-closable']/div[@class='x-toolbar x-docked x-toolbar-footer x-docked-bottom x-toolbar-docked-bottom x-toolbar-footer-docked-bottom x-box-layout-ct']/div/div/div[@id='CloseBtn']/em/button"));
                    executor.ExecuteScript("arguments[0].click();", userProfileCloseBtn);
                    System.Threading.Thread.Sleep(1000);

                }
                catch (NoSuchElementException e)
                {
                    logger.Error("Unable to click on 'CLOSE' button on the USER PROFILE form for carrier - " + username + ". " + e.Message);
                }



                //Click on "X" button on the "Profile Status" popup
                try
                {
                    var notificationPopupTitle = driver.FindElement(By.XPath("//body/div[@class='x-window x-notification x-layer x-window-default x-closable x-window-closable x-window-default-closable']/div[@class='x-window-header x-docked x-window-header-default x-horizontal x-window-header-horizontal x-window-header-default-horizontal x-top x-window-header-top x-window-header-default-top x-docked-top x-window-header-docked-top x-window-header-default-docked-top x-unselectable']"));

                    //executor.ExecuteScript("arguments[0].click();", notificationPopupTitle);
                    action.MoveToElement(notificationPopupTitle).Click().Build().Perform();
                    System.Threading.Thread.Sleep(1000);


                    var notificationPopupCloseBtn = driver.FindElement(By.XPath("//body/div[@class='x-window x-notification x-layer x-window-default x-closable x-window-closable x-window-default-closable']/div/div/div/div/div[@class='x-tool x-box-item x-tool-default']"));

                    //executor.ExecuteScript("arguments[0].click();", notificationPopupCloseBtn);
                    //notificationPopupCloseBtn.Click();
                    action.MoveToElement(notificationPopupCloseBtn).Click().Build().Perform();
                    System.Threading.Thread.Sleep(1000);


                }
                catch (NoSuchElementException e)
                {
                    logger.Error("Unable to click on 'X' button on the PROFILE STATUS popup for carrier - " + username + ". " + e.Message);
                }
               
            }
        }

        


        private void SubmitPricesByCarrier(String username, String password, String matrixFilelocation)
        {
            LogInUserCarrier(username, password, "//iframe[contains(@src,'/TenderList/CarrierGridView')]");
            CloseUserProfileForm(username);
            SelectEnglishLanguage(10, "//iframe[contains(@src,'/TenderList/CarrierGridView')]");
            FindAndAcceptPublishedTender(username);
            CheckAvailableTenderParts(username);
            AcceptTermsAndConditions(username);
            OpenBiddingMatrixAndSubmitPrices(username, matrixFilelocation);

        }


        private void TestingAnalysisPartsAndAwarding()
        {
            CheckAvailableAnalysisParts();
            TestOverviewCarriers();
            TestOverviewScenarios();
            TestLowerGridOfDefaultScenario();
            //TestAwardingProcess();
            CreateManualAllocationScenarioWithFilters();

        }



        private void BuildShipperUser(string user, string password)
        {
            CurrentUser = new LogInModel() { UserName = user, Password = password };
        }

        private void RunChromeCreateTenderTest()
        {
            SetupChromeEnvironment();
            LogOut();
            SetUpCreateTenderTestSettings();
            // Just for test TO DO remove CloseCompatibilityModeWindow from here
            CloseCompatibilityModeWindow();
            LogInCurrentUser();
            CreateTender();
            LogOut();
            WaitForLoad(driver);
        }
        private void RunIECreateTenderTest()
        {
               SetupIEEnvironment();
               LogOut();
               SetUpCreateTenderTestSettings();
            // Just for test TO DO remove CloseCompatibilityModeWindow from here
               CloseCompatibilityModeWindow();
               LogInCurrentUser();
               SelectEnglishLanguage(9, "//iframe[contains(@src,'/TenderList/ShipperGridView')]");   
               /*CreateTender();
               GetCreatedTenderREF();
               LogOut();
               WaitForLoad(driver);
               LogInUserAdmin("admin", "admin?987", "//iframe[contains(@src,'/TenderList/AdminGridView')]");
               FindAndApprovePublishedTender();
               LogOut();
               WaitForLoad(driver);
               SubmitPricesByCarrier("c11", "admin", "D:/ccx3/Storage/c11.cmx");
               LogOut();
               WaitForLoad(driver);
               SubmitPricesByCarrier("c16", "admin", "D:/ccx3/Storage/c16.cmx");
               LogOut();
               WaitForLoad(driver);
               SubmitPricesByCarrier("c21", "admin", "D:/ccx3/Storage/c21.cmx");
               LogOut();
               WaitForLoad(driver);
               WaitTillAnalysisGetsActivated();*/
               FindAndOpenTenderWithAnalysis();
               TestingAnalysisPartsAndAwarding();
             //Timer1();
               LogOut();
               WaitForLoad(driver);
        }



        private void RunFireFoxCreateTenderTestt()
        {
            SetupFireFoxEnvironment();
            LogOut();
            SetUpCreateTenderTestSettings();
            // Just for test TO DO remove CloseCompatibilityModeWindow from here
            CloseCompatibilityModeWindow();
            LogInCurrentUser();
            CreateTender();
            LogOut();
            WaitForLoad(driver);
        }

        private void RunChromeLoginTest()
        {
            SetupChromeEnvironment();
            LogOut();
            SetUpLogInTestSettings();
            CheckChromeBrowserSettings();
            //CheckStartLoadingForm();
            CloseCompatibilityModeWindow();
            LogInCurrentUser();
            CheckIsShipperTenderAllTabExist();
            var watch = System.Diagnostics.Stopwatch.StartNew();
            SelectEnglishLanguage(9, "//iframe[contains(@src,'/TenderList/ShipperGridView')]");
            WaitForLoad(driver);
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            var res = (double)elapsedMs / 1000;
            if (res > 10)
            {
                logger.Info(string.Format("#Warning '{0}' took quite a long time: {1} sec!", "Change language", res.ToString()));
            }
            LogOut();
            WaitForLoad(driver);
        }
        private void RunFireFoxLoginTest()
        {
            SetupFireFoxEnvironment();
            LogOut();
            SetUpLogInTestSettings();
            CheckFireFoxBrowserSettings();
            //CheckStartLoadingForm();
            CloseCompatibilityModeWindow();
            LogInCurrentUser();
            CheckIsShipperTenderAllTabExist();
            var watch = System.Diagnostics.Stopwatch.StartNew();
            SelectEnglishLanguage(9, "//iframe[contains(@src,'/TenderList/ShipperGridView')]");
            WaitForLoad(driver);
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            var res = (double)elapsedMs / 1000;
            if (res > 10)
            {
                logger.Info(string.Format("#Warning '{0}' took quite a long time: {1} sec!", "Change language", res.ToString()));
            }
            LogOut();
            WaitForLoad(driver);
        }
        private void RunIELoginTest()
        {
            SetupIEEnvironment();
            LogOut();
            SetUpLogInTestSettings();
            CheckIEBrowserSettings();
            //CheckStartLoadingForm();
            CloseCompatibilityModeWindow();
            LogInCurrentUser();
            CheckIsShipperTenderAllTabExist();
            var watch = System.Diagnostics.Stopwatch.StartNew();
            SelectEnglishLanguage(9, "//iframe[contains(@src,'/TenderList/ShipperGridView')]");
            WaitForLoad(driver);
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            var res = (double)elapsedMs / 1000;
            if (res > 10)
            {
                logger.Info(string.Format("#Warning '{0}' took quite a long time: {1} sec!", "Change language", res.ToString()));
            }
            LogOut();
            WaitForLoad(driver);
        }



        //  [TestMethod]
        public void Test_Create_Shipper_All_Tender_Screen()
        {
            SetupChromeEnvironment();
            LogOut();
            SetUpVerifyScreensTestSettings();
            CloseCompatibilityModeWindow();
            LogInCurrentUser();
            SelectEnglishLanguage(9, "//iframe[contains(@src,'/TenderList/ShipperGridView')]");
            WaitForLoad(driver);

            System.Threading.Thread.Sleep(5000);

            driver.SwitchTo().Frame(driver.FindElements(By.TagName("iframe"))[0]);
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            var filterBtn = driver.FindElement(By.XPath("//*[@id='filterButton-btnEl']"));
            executor.ExecuteScript("arguments[0].click();", filterBtn);
            var filterRef = driver.FindElement(By.XPath("//*[@id='filterRef-inputEl']"));
            filterRef.SendKeys(CurrentUser.VerifyScreensTenderRef);
            var applyFilter = driver.FindElement(By.XPath("//*[@id='button-1037-btnEl']"));
            executor.ExecuteScript("arguments[0].click();", applyFilter);
            WaitForAjax();
            executor.ExecuteScript("arguments[0].click();", filterBtn);

            string workPath = testContext.Properties["ScreenPath"].ToString();
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile(Path.Combine(workPath, "master_shipper_tender_all.png"), ScreenshotImageFormat.Png);
        }



        public void TakeScreenshotOfWebElement(String elementXPath, String fileNameWithExtension)
        {
            //string workPath = testContext.Properties["ScreenPath"].ToString();

            // path to save screenshots  
            string projectCurrentPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            Console.WriteLine("PROJECT's CURRENT PATH {0}", projectCurrentPath);
            var ScreenshotFilePath = Path.Combine(projectCurrentPath, "uitests\\");
            string workPath = new Uri(ScreenshotFilePath).LocalPath;
             Console.WriteLine("Actual Screenshot's Path {0}", workPath);

            // Get the element position (scroll-aware)
            IWebElement element = driver.FindElement(By.XPath(elementXPath));
            var locationWhenScrolled = ((RemoteWebElement)element).LocationOnScreenOnceScrolledIntoView;

            var byteArray = ((ITakesScreenshot)driver).GetScreenshot().AsByteArray;
            using (var screenshot = new System.Drawing.Bitmap(new System.IO.MemoryStream(byteArray)))
            {
                var location = locationWhenScrolled;
                // Fix location if necessary to avoid OutOfMemory Exception
                if (location.X + element.Size.Width > screenshot.Width)
                {
                    location.X = screenshot.Width - element.Size.Width;
                }
                if (location.Y + element.Size.Height > screenshot.Height)
                {
                    location.Y = screenshot.Height - element.Size.Height;
                }
                // Crop the screenshot
                var croppedImage = new System.Drawing.Rectangle(location.X, location.Y, element.Size.Width, element.Size.Height);
                using (var clone = screenshot.Clone(croppedImage, screenshot.PixelFormat))
                {
                    clone.Save(workPath + fileNameWithExtension, ImageFormat.Png);
                    screenshot.Dispose();
                    clone.Dispose();
                }
            }
        }




        public void CompareScreenshots(String masterFileName, String actualFileName, String differenceFileName)
        {
            // string workPath = testContext.Properties["ScreenPath"].ToString();

            // path to save screenshots  
            string projectCurrentPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            Console.WriteLine("PROJECT's CURRENT PATH {0}", projectCurrentPath);
            var ScreenshotFilePath = Path.Combine(projectCurrentPath, "uitests\\");
            string workPath = new Uri(ScreenshotFilePath).LocalPath;
            Console.WriteLine("Actual Screenshot's Path {0}", workPath);



            Snapshot master = Snapshot.FromFile(Path.Combine(workPath, masterFileName));
            Snapshot actual = Snapshot.FromFile(Path.Combine(workPath, actualFileName));
            Snapshot difference = actual.CompareTo(master);
            SnapshotVerifier v = new SnapshotColorVerifier(Color.Black, new ColorDifference());
            if (v.Verify(difference) == VerificationResult.Fail)
            {
                difference.ToFile(Path.Combine(workPath, differenceFileName), ImageFormat.Png);
                logger.Warn("The " + masterFileName + " screenshot is NOT the same as the " + actualFileName + " screenshot. A difference screenshot " + differenceFileName + " was created.");
            }
            else
            {
                logger.Info("The " + masterFileName + " screenshot is the SAME as the " + actualFileName + " screenshot.");
            }



        }



        public void CompareScreenshots2(String masterFileName, String actualFileName, String differenceFileName, int Tollerance) 
        {
            //string workPath = testContext.Properties["ScreenPath"].ToString();

            // path to save screenshots  
            string projectCurrentPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            Console.WriteLine("PROJECT's CURRENT PATH {0}", projectCurrentPath);
            var ScreenshotFilePath = Path.Combine(projectCurrentPath, "uitests\\");
            string workPath = new Uri(ScreenshotFilePath).LocalPath;
            Console.WriteLine("Actual Screenshot's Path {0}", workPath);


            Image img1 = Image.FromFile(Path.Combine(workPath, masterFileName));
            Bitmap Image1 = new Bitmap(img1);

            Image img2 = Image.FromFile(Path.Combine(workPath, actualFileName));
            Bitmap Image2 = new Bitmap(img2);

            int Image1Size = Image1.Width * Image1.Height;
            int Image2Size = Image2.Width * Image2.Height;


            //Image img3 = Image.FromFile(Path.Combine(workPath, differenceFileName));
            Bitmap Image3;

            if (Image1Size == Image2Size)

            {
                //Image1 = new Bitmap(Image1, Image2.Size);
                Image3 = new Bitmap(Image2.Width, Image2.Height);

                for (int x = 0; x < Image1.Width; x++)
                {
                    for (int y = 0; y < Image1.Height; y++)
                    {
                        Color Color1 = Image1.GetPixel(x, y);
                        Color Color2 = Image2.GetPixel(x, y);
                        int r = Color1.R > Color2.R ? Color1.R - Color2.R : Color2.R - Color1.R;
                        int g = Color1.G > Color2.G ? Color1.G - Color2.G : Color2.G - Color1.G;
                        int b = Color1.B > Color2.B ? Color1.B - Color2.B : Color2.B - Color1.B;
                        Image3.SetPixel(x, y, Color.FromArgb(r, g, b));
                    }
                }

                int Difference = 0;
                for (int x = 0; x < Image1.Width; x++)
                {
                    for (int y = 0; y < Image1.Height; y++)
                    {
                        Color Color1 = Image3.GetPixel(x, y);
                        int Media = (Color1.R + Color1.G + Color1.B) / 3;
                        if (Media > Tollerance)
                            Difference++;
                    }
                }
                double UsedSize = Image1Size > Image2Size ? Image2Size : Image1Size;
                double result = Difference * 100 / UsedSize;

                if (result > Tollerance) {
                    
                    logger.Error("Difference between the screenshot " + masterFileName + " and the screenshot " + actualFileName + " is " + Math.Round(Difference * 100 / UsedSize, 2, MidpointRounding.AwayFromZero) + "%");
                    driver.Quit();
                }
                else
                {
                    logger.Info("Difference between the screenshot " + masterFileName + " and the screenshot " + actualFileName + " is " + Math.Round(Difference * 100 / UsedSize, 2, MidpointRounding.AwayFromZero) + "%");

                }

                string filePath = Path.Combine(workPath, differenceFileName);
                Image3.Save(filePath, ImageFormat.Png);                               

            }
            else
            {

                logger.Info("The " + masterFileName + " screenshot SIZE is NOT the SAME as the SIZE of " + actualFileName + " screenshot.");

            }

       


    }


        public double CompareScreenshotsMatrix(String masterFileName, String actualFileName, int Tollerance)
        {
            // string workPath = testContext.Properties["ScreenPath"].ToString();
            
            // path to save screenshots  
            string projectCurrentPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            Console.WriteLine("PROJECT's CURRENT PATH {0}", projectCurrentPath);
            var ScreenshotFilePath = Path.Combine(projectCurrentPath, "uitests\\");
            string workPath = new Uri(ScreenshotFilePath).LocalPath;
            Console.WriteLine("Actual Screenshot's Path {0}", workPath);


            double result = 99.99;

            Image img1 = Image.FromFile(Path.Combine(workPath, masterFileName));
            Bitmap Image1 = new Bitmap(img1);

            Image img2 = Image.FromFile(Path.Combine(workPath, actualFileName));
            Bitmap Image2 = new Bitmap(img2);

            int Image1Size = Image1.Width * Image1.Height;
            int Image2Size = Image2.Width * Image2.Height;


            //Image img3 = Image.FromFile(Path.Combine(workPath, differenceFileName));
            Bitmap Image3;

            if (Image1Size == Image2Size)

            {
                //Image1 = new Bitmap(Image1, Image2.Size);
                Image3 = new Bitmap(Image2.Width, Image2.Height);

                for (int x = 0; x < Image1.Width; x++)
                {
                    for (int y = 0; y < Image1.Height; y++)
                    {
                        Color Color1 = Image1.GetPixel(x, y);
                        Color Color2 = Image2.GetPixel(x, y);
                        int r = Color1.R > Color2.R ? Color1.R - Color2.R : Color2.R - Color1.R;
                        int g = Color1.G > Color2.G ? Color1.G - Color2.G : Color2.G - Color1.G;
                        int b = Color1.B > Color2.B ? Color1.B - Color2.B : Color2.B - Color1.B;
                        Image3.SetPixel(x, y, Color.FromArgb(r, g, b));
                    }
                }

                int Difference = 0;
                for (int x = 0; x < Image1.Width; x++)
                {
                    for (int y = 0; y < Image1.Height; y++)
                    {
                        Color Color1 = Image3.GetPixel(x, y);
                        int Media = (Color1.R + Color1.G + Color1.B) / 3;
                        if (Media > Tollerance)
                            Difference++;
                    }
                }
                double UsedSize = Image1Size > Image2Size ? Image2Size : Image1Size;
                //result = Difference * 100 / UsedSize;
                result =  Math.Round(Difference * 100 / UsedSize, 2, MidpointRounding.AwayFromZero);

               /* if (result > Tollerance)
                {

                    logger.Error("Difference between the screenshot " + masterFileName + " and the screenshot " + actualFileName + " is " + Math.Round(Difference * 100 / UsedSize, 2, MidpointRounding.AwayFromZero) + "%");
                    driver.Quit();
                }
                else
                {
                    logger.Info("Difference between the screenshot " + masterFileName + " and the screenshot " + actualFileName + " is " + Math.Round(Difference * 100 / UsedSize, 2, MidpointRounding.AwayFromZero) + "%");

                }*/

               // string filePath = Path.Combine(workPath, differenceFileName);
               // Image3.Save(filePath, ImageFormat.Png);

            }
            else
            {

                logger.Info("The " + masterFileName + " screenshot SIZE is NOT the SAME as the SIZE of " + actualFileName + " screenshot.");

            }

            return result;


        }




        public void DeleteScreenshot(String screenshotFileName)
        {
            // string workPath = testContext.Properties["ScreenPath"].ToString();

            // path to save screenshots  
            string projectCurrentPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            Console.WriteLine("PROJECT's CURRENT PATH {0}", projectCurrentPath);
            var ScreenshotFilePath = Path.Combine(projectCurrentPath, "uitests\\");
            string workPath = new Uri(ScreenshotFilePath).LocalPath;
            Console.WriteLine("Actual Screenshot's Path {0}", workPath);
            

            var filestream = new System.IO.FileStream(Path.Combine(workPath, screenshotFileName), System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite);
            filestream.Close();
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
            File.Delete(Path.Combine(workPath, screenshotFileName));
            
        }
        
    }
}
