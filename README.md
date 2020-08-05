# GK_Assessment

This repository is used to store the active GK assessment assigned to the repository owner.

## Project Section Completion Times:

### Commit times were used to estimate/track completion times:

* Section 1 - Web Automation:
	* 1 Hour
* Section 2 - API Automation:
	* 1 Hour
* Section 3 - Mobile Automation:
	* 3 Hours

Total Time Spent: 5 Hours

## Project Setup:

Please see the below instructions to clone this repository and execute the code contained within.

### Prerequisites:

* Visual Studio (Preferred IDE used within development)
* .NET Core 3.1
* .NET Framework 4.7

### Cloning the repository:

1. Ensure all the above listed prerequisites is installed/available on the target machine.
2. Clone this repository onto the target machine.
3. Open the project in Visual Studio. (Visual Studio 2019 Community Edition was used for development of this repository)
4. Build the solution.

### Executing tests:
1. Open the Test Explorer.
2. Use the test explorer to execute any of the tests located within the project.

### Test Execution Notes:

To execute the "MobileAutomationScenario" test, a Device ID and Platform Version (OS) is required as parameters to instantiate the WebDriver used to control the device.
A physical device was used to test this unit test within development.

## Project Packages:

* Appium WebDriver 4.1.1
* NUnit 3.12.0
* NUnit 3 TestAdapter 3.17.0
* Selenium Support 3.141.0
* Selenium WebDriver 3.141.0
* Selenium WebDriver ChromeDriver 84.0.4147.3001

## Project Folder Structures:

* apkFiles
	* Contains any apk files used within mobile unit tests.
* ModelClasses
	* Contains any model classes used within serialization of input or output data
* TestClasses
	* All test process classes are contained within this folder.
	* All test steps are created within this folder using classes from the Utilities folder as required.
* TestData
	* This folder contains all test data input files used within unit tests.
* UnitTests
	* Contains all unit test classes within the project.
* Utilities
	* This folder contains all classes used to create methods for the project packages.
	* This folder also contains utility classes used for generic/frequently used functions.