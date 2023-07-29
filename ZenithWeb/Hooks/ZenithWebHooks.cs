
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Gherkin.Model;
using ZenithWeb.Drivers;
[assembly: Parallelizable(ParallelScope.Fixtures)]
[assembly: LevelOfParallelism(2)]

namespace ZenithWeb.Hooks
{
    [Binding]
    public sealed class ZenithWebHooks
    {
        private DriverHelper _driverHelper;
      

        public ZenithWebHooks(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
      
        }




        static string configTheme = "dark";
        static string configReportPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "AutomationResults", "ExtentReport.html");
        //static string configReportPath = @$"C:\AutomationResults\ExtentReport.html";


        [ThreadStatic]
        private static ExtentTest feature;
        [ThreadStatic]
        private static ExtentTest scenario;
        private static ExtentReports extentReport;
        private static readonly string base64ImageType = "base64";

        [BeforeTestRun]
        public static void InitializeReport()
        {
            //Initialize Extent report before test starts
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(configReportPath);

            switch (configTheme.ToLower())
            {
                case "dark":
                    htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
                    break;
                case "standard":
                default:
                    htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;
                    break;
            }

            //Attach report to reporter
            extentReport = new ExtentReports();
            extentReport.AttachReporter(htmlReporter);
        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            extentReport.Flush();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            feature = extentReport.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void InitializeScenario(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            scenario = feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
            SelectBrowser(BrowserType.Chrome);
        }

        [AfterScenario]
        public void CleanUp(ScenarioContext scenarioContext)
        {

            //to check if we missed to implement any step
            string resultOfImplementation = scenarioContext.ScenarioExecutionStatus.ToString();


            //Pending Status
            if (resultOfImplementation == "UndefinedStep")
            {
                // Log.StepNotDefined();
            }
            _driverHelper.Driver.Quit();
        }

        [AfterStep]
        public void InsertReportingSteps(ScenarioContext scenarioContext)
        {
            string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            string stepInfo = scenarioContext.StepContext.StepInfo.Text;


            //to check if we missed to implement steps inside method
            string resultOfImplementation = scenarioContext.ScenarioExecutionStatus.ToString();


            if (scenarioContext.TestError == null && resultOfImplementation == "OK")
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(stepInfo);
                else if (stepType == "When")
                    scenario.CreateNode<When>(stepInfo);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(stepInfo);
                else if (stepType == "And")
                    scenario.CreateNode<And>(stepInfo);
                else if (stepType == "But")
                    scenario.CreateNode<And>(stepInfo);
            }
            else if (scenarioContext.TestError != null)
            {
                Exception? innerException = scenarioContext.TestError.InnerException;
                string? testError = scenarioContext.TestError.Message;

                if (stepType == "Given")
                    scenario.CreateNode<Given>(stepInfo).Fail(innerException, MediaEntityBuilder.CreateScreenCaptureFromBase64String(base64ImageType).Build());
                else if (stepType == "When")
                    scenario.CreateNode<When>(stepInfo).Fail(innerException, MediaEntityBuilder.CreateScreenCaptureFromBase64String(base64ImageType).Build());
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(stepInfo).Fail(testError, MediaEntityBuilder.CreateScreenCaptureFromBase64String(base64ImageType).Build());
                else if (stepType == "And")
                    scenario.CreateNode<Then>(stepInfo).Fail(testError, MediaEntityBuilder.CreateScreenCaptureFromBase64String(base64ImageType).Build());
                else if (stepType == "But")
                    scenario.CreateNode<Then>(stepInfo).Fail(testError, MediaEntityBuilder.CreateScreenCaptureFromBase64String(base64ImageType).Build());

            }
            else if (resultOfImplementation == "StepDefinitionPending")
            {
                string errorMessage = "Step Definition is not implemented!";

                if (stepType == "Given")
                    scenario.CreateNode<Given>(stepInfo).Fail(errorMessage, MediaEntityBuilder.CreateScreenCaptureFromBase64String(base64ImageType).Build());
                else if (stepType == "When")
                    scenario.CreateNode<When>(stepInfo).Fail(errorMessage, MediaEntityBuilder.CreateScreenCaptureFromBase64String(base64ImageType).Build());
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(stepInfo).Fail(errorMessage, MediaEntityBuilder.CreateScreenCaptureFromBase64String(base64ImageType).Build());
                else if (stepType == "But")
                    scenario.CreateNode<Then>(stepInfo).Fail(errorMessage, MediaEntityBuilder.CreateScreenCaptureFromBase64String(base64ImageType).Build());

            }

        }



        internal void SelectBrowser(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    ChromeOptions options = new ChromeOptions();
                    options.AddArguments("start-maximized");
                    options.AddArguments("--disable-gpu");
                   // options.AddArguments("--headless");

                    _driverHelper.Driver = new ChromeDriver(options);

                    break;
                case BrowserType.Firefox:
                    FirefoxOptions option = new FirefoxOptions();

                    _driverHelper.Driver = new FirefoxDriver(option);
                    _driverHelper.Driver.Manage().Window.Maximize();
                    break;
                case BrowserType.Edge:
                    EdgeOptions opt = new EdgeOptions();

                    _driverHelper.Driver = new EdgeDriver(opt);
                    _driverHelper.Driver.Manage().Window.Maximize();
                    opt.AddArguments("headless");


                    break;
                default:
                    break;
            }
        }

    }

    enum BrowserType
    {
        Chrome,
        Firefox,
        Edge
    }

}
