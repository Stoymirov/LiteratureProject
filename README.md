Bulgarian and Literature Exam Preparation Platform

This project is designed to assist students in preparing for their Bulgarian and Literature exams. The platform offers tools to practice, review analyses, and test knowledge through an interactive web application.

Features

Bulgarian Module: Teachers can create decks of problems that students can solve.

Literature Module: Teachers can add analyses related to literature topics, which students can read for better understanding.

Testing Module: Enables students to test themselves with quizzes to assess their knowledge.

Profile Management: Each user has a profile for tracking progress and activities.

Admin Dashboard: Admin users can manage content, oversee platform activities, assign users as teachers or students, and access detailed dashboards for monitoring.

Technologies Used

Frontend: HTML, CSS

Backend: ASP.NET with C#

Database: Entity Framework (Code First Approach)

Cloud: Google Cloud Platform for deployment and hosting

Getting Started

Prerequisites

To run the project locally, ensure you have:

Visual Studio with ASP.NET and C# development tools

.NET SDK installed

SQL Server or a compatible database setup

A Google Cloud account (optional, for cloud hosting)

Setup Instructions

Clone the Repository:

git clone <repository-url>
cd <project-folder>

Database Configuration:

Update the connection string in the appsettings.json file to match your database setup.

Run the following command in the Package Manager Console to apply migrations:

Update-Database

Seeded Admin User:
The application includes a default admin user seeded into the database. Use the following credentials to log in as an admin:

Email: admin@example.com

Password: Admin123!

Run the Application:

In Visual Studio, press Ctrl+F5 to build and run the application.

Hosting on Google Cloud

To deploy the application on Google Cloud:

Set up a new project on Google Cloud Platform.

Configure App Engine or a Compute Engine instance.

Deploy your project using the gcloud CLI or the deployment tools in Visual Studio.

Project Structure

Controllers:

BulgarianController: Manage Bulgarian decks and problems.

LiteratureController: Add and view literature analyses.

TestingController: Handle self-testing functionalities.

ProfileController: Manage user profiles.

AdminController: Admin tools for managing the application and assigning roles.

Views: Razor Pages for user interface.

Models: Entity Framework models for database interactions.

Migrations: Contains database migration files.

Usage

Admin User:

Log in with the seeded admin credentials to assign users as teachers or students, manage content, and monitor platform activities via the dashboard.

Teachers:

Add decks of problems and literature analyses for students to use.

Students:

Register for an account to access decks, read literature analyses, and test yourself.

Future Enhancements

Add a leaderboard to encourage competitive learning.

Include more interactive testing formats.

Support multi-language content for Bulgarian and English users.

License

This project is licensed under the MIT License.
