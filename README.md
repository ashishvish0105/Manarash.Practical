Developed By: Ashish Vishwakarma
Role: Full Stack Developer – .NET Core & Angular
Experience: 4+ Years

1. Project Overview
  The Warehouse Dock Booking Management System is a web application designed to manage truck bookings and operations at warehouse loading and unloading docks.
  A warehouse has multiple docks (loading bays), where different trucking companies can book time slots to load or unload goods.
  The application manages the complete truck process, from booking a dock slot to checking in, dock assignment, and final departure.

2. Technologies Used
    - .NET 9.0
    - Angular CLI 21.1.1
    - Node.js 22.12.0
    - npm 10.9.0
    - Operating System: Windows 64-bit

3. Prerequisites
  Before running the project, install the following software:

    - .NET 9 SDK
    - Node.js 22.12.0
    - npm 10.9.0
    - Angular CLI 21.1.1
    - Visual Studio / Visual Studio Code
    - Git

Make sure your system environment is configured according to the required versions.

4. Clone the Repository
  - Open Command Prompt or Terminal and execute the following command:
  - git clone https://github.com/ashishvish0105/Manarash.Practical.git

  Navigate to the project directory:
    - cd Manarash.Practical

5. Frontend Setup (Angular)
  - Open Command Prompt and navigate to the folder containing package.json.
  - Install the required packages:
      npm install --legacy-peer-deps

  - Start the Angular application:
    npm start

  - Alternatively :
      ng serve -o

The application will start, and the browser will open automatically when using ng serve -o.

6. Backend Setup (.NET Core)
Follow these simple steps to set up and run the backend project.

  Step 1: Open Backend Project
          - Open the backend project in Visual Studio.

  Step 2: Check .NET Version
          - Open the .csproj file and verify:
              <TargetFramework>net9.0</TargetFramework>

  Step 3: Configure Database
          - Open appsettings.json and add your database connection string.
  
  Step 4: Open NuGet Package Manager Console
          - Tools → NuGet Package Manager → Package Manager Console

  Step 5: Create Database Migration
          - Run the following command:
          - Add-Migration InitialCreate

  Step 6: Update Database
          - Update-Database

  Step 7: Check Backend
          - Make sure the project runs without errors.
          - Check that the database is created successfully.
          - Open the Swagger URL (if available) to test the APIs.

Note: Make sure the database connection string is correct and all Entity Framework Core packages use compatible versions.


The backend API will start using the configured application URL and port.

7. Running the Complete Project
  - Start the .NET backend application.
  - Start the Angular frontend application.
  - Configure the frontend API URL to match the backend URL.
  - Open the Angular application in your browser.
  - Start using the Warehouse Dock Booking Management System.


Note: Make sure all required software and dependencies are installed before running the project. Also, verify that the frontend and backend API configurations are correct.

8. Assumptions Made
A. Dock Management
  Implemented complete CRUD operations (Add, Edit, View, and Delete) for dock management.
  Used a single reusable form for both Add and Edit operations.
  Added a toggle switch to activate or deactivate a dock.
  Implemented form validations for all required fields.
  Managed dock status and dock type (Inbound, Outbound, and Both).

B. Booking Management
  Implemented complete CRUD operations for booking management.
  Used a single reusable form for both Add and Edit bookings.
  Added dock selection in the booking form.
  Based on the selected dock, displayed the available booking directions (Inbound, Outbound, or Both).
  Applied all required form validations.
  Implemented Toastr notifications to display success and error messages.

C. Booking Business Validations
  Implemented the following booking validations:

  Two active bookings on the same dock cannot overlap in time.
  A booking ending at 11:00 AM and another starting at 11:00 AM are allowed.
  A booking cannot be created with a past start date or time.
  An inactive dock cannot accept new bookings.
  The booking direction must match the selected dock type.
  A dock with the Both type accepts both Inbound and Outbound bookings.

10. What I Could Not Finish
Due to time limitations, I could not complete the following features:

  A. Booking Status Management
    The required booking status flow is:
    Booked → CheckedIn → AtDock → Departed

    A booking can also be Cancelled.
    Cancellation is allowed only when the booking status is Booked.
    Display a button for the next valid status on the booking screen.
    Invalid status changes should be rejected by the backend with a clear error message.
    B. Booking List Screen

The following features are pending:
  Pagination for the booking list.
  Filter bookings by status.
  Filter bookings by dock.
  Search bookings by vehicle plate number, company name, or booking reference.
  Implement filtering, searching, and pagination directly in database queries instead of loading all records into memory.

C. Optional Bonus Features
  Due to time limitations, I could not complete the optional bonus features:
  
  Unit tests for booking business rules.
  A simple day-view screen to display bookings for a selected dock and date.


11. What I Would Improve With More Time
    - If I had more time, I would focus on the following improvements:

  Automated Testing:         Implement unit tests and integration tests to improve application reliability and ensure all business rules work correctly.
  Dapper Integration:        Use Dapper for faster data retrieval and better query performance where appropriate.
  Performance Optimization:  Optimize database queries, reduce unnecessary API calls, and improve overall application performance.
  Booking Status Management: Complete the booking status workflow with proper backend validation and user-friendly error messages.
  Booking List Improvements: Complete server-side pagination, filtering, and searching for better performance.
  Code Quality:              Improve code reusability, maintainability, and error handling across the application.
