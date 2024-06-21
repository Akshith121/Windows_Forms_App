## Windows Forms App
### Description
Windows Forms App is a Windows Forms application developed in Visual Basic. The application allows users to create, view, and manage form submissions. The application comprises four main forms: `Form1`, `ViewSubmissionsForm`, `CreateSubmissionForm`, and `ThankYouForm`.

### Installation

 1. Clone the repository:
      ```sh
      git clone https://github.com/Akshith121/Windows_Forms_App.git
      ```
     
 2. Open the solution file (`.sln`) in Visual Studio.
        -   Launch Visual Studio.
        -   Click on `File` > `Open` > `Project/Solution...`.
        -   Navigate to the directory where you cloned the repository.
        -   Select the `.sln` file and click `Open`.
 3. Build the project to restore the necessary packages.
        -   In Visual Studio, click on `Build` > `Build Solution` (or press `Ctrl+Shift+B`).
        -   This will compile the code and restore any missing NuGet packages.
        -   You can also manually restore NuGet packages by right-clicking on the solution in the Solution Explorer and selecting `Restore NuGet Packages`.
        -   Check the `Output` window in Visual Studio to ensure the build was successful.

### Usage

 1. **Run the application**: Start the application by pressing `F5` or selecting `Debug > Start Debugging` in Visual Studio.
 2. **Navigate the forms:**
         -   **Form1**: The main form that provides options to view submissions or create a      new submission.
        -   **ViewSubmissionsForm**: Displays a list of all form submissions.
        -   **CreateSubmissionForm**: Allows the user to create a new form submission.
        -   **ThankYouForm**: Displays a thank you message after a form submission and provides options to edit the response or delete the form.
 
## Forms Overview

### Form1
The main entry point of the application. It includes buttons to navigate to the `ViewSubmissionsForm` and `CreateSubmissionForm`.
### ViewSubmissionsForm
Displays all form submissions in a list. Allows users to view details of each submission. It includes two buttons which allow user to navigate to next and previous forms.
### CreateSubmissionForm
A form where users can create new submissions. After a successful submission, it navigates to the `ThankYouForm`.
### ThankYouForm
Displays a thank you message to the user after a form submission. It also provides options to edit the response or delete the form.
