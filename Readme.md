# endpoints 
auth:
POST /api/auth/register/trainer: Register a new trainer.
POST /api/auth/register/student: Register a new student.

Trainers:
POST /api/trainer/add-course/{trainerId}: Trainers can add courses they teach.

Students:
POST /api/student/enroll-course/{studentId}: Students can enroll in courses.

Courses:
GET /api/course: Get all courses.
POST /api/course: Create a new course (accessible to admins only).
This setup should give you a comprehensive API structure for managing trainers, students, and courses, with JWT-based authentication.
## migrations
dotnet ef migrations add InitialAuthMigration -c AuthDbContext
dotnet ef migrations add InitialTrainingMigration -c TrainingDbContext
dotnet ef database update -c AuthDbContextS
dotnet ef database update -c TrainingDbContext
