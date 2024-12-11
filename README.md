# Bulgarian and Literature Exam Preparation Platform

This project is designed to assist students in preparing for their Bulgarian and Literature exams. The platform offers tools to practice, review analyses, and test knowledge through an interactive web application.

## Features

- **Bulgarian Module**: Teachers can create decks of problems that students can solve.
- **Literature Module**: Teachers can add analyses related to literature topics, which students can read for better understanding.
- **Testing Module**: Enables students to test themselves with quizzes to assess their knowledge.
- **Profile Management**: Each user has a profile for tracking progress and activities.
- **Admin Dashboard**: Admin users can manage content, oversee platform activities, assign users as teachers or students, and access detailed dashboards for monitoring.

## Technologies Used

- **Frontend**: HTML, CSS
- **Web**  ASP.NET with C#
- **Database**: Entity Framework (Code First Approach)
- **Cloud**: Google Cloud Platform for photos

## Admin User Setup

The application includes a seeded admin user. Use the following credentials to log in as an admin:

- **Email**: admin@example.com
- **Password**: Admin123!

Once logged in, the admin can manage user roles, assign users as teachers or students, and oversee platform activities through the admin dashboard.

## Project Structure

- **Controllers**:
  - `BulgarianController`: Manages Bulgarian problem decks.
  - `LiteratureController`: Manages literature analyses.
  - `TestingController`: Handles quiz functionality.
  - `ProfileController`: Manages user profile-related operations.
  - `AdminController`: Provides tools for managing content, roles, and platform settings.

- **Views**: Razor Pages used for building the user interface of the platform.
  
- **Models**: Contains Entity Framework models for handling database interactions.

- **Migrations**: Holds migration files for updating and syncing the database schema with the application.
