using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NTT.CafeManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSampleData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Insert Cafes
            migrationBuilder.Sql(@"
                INSERT INTO cafes (id, name, description, location, logo_url)
                VALUES 
                ('11111111-1111-1111-1111-111111111111', 'Cafe One', 'A cozy cafe for coffee lovers.', 'Singapore City', 'https://example.com/logo1.png'),
                ('22222222-2222-2222-2222-222222222222', 'Cafe Two', 'Known for its amazing latte art.', 'Bedok', 'https://example.com/logo2.png'),
                ('33333333-3333-3333-3333-333333333333', 'Cafe Three', 'Perfect spot for a peaceful brunch.', 'Tampines', 'https://example.com/logo3.png'),
                ('44444444-4444-4444-4444-444444444444', 'Cafe Four', 'Great place for meetings.', 'Jurong', 'https://example.com/logo4.png'),
                ('55555555-5555-5555-5555-555555555555', 'Cafe Five', 'Casual cafe with friendly staff.', 'Ang Mo Kio', 'https://example.com/logo5.png'),
                ('66666666-6666-6666-6666-666666666666', 'Cafe Six', 'Newly opened and trending.', 'Clementi', 'https://example.com/logo6.png');
            ");

            // Insert Employees
            migrationBuilder.Sql(@"
                INSERT INTO employees (id, name, email, phone_number, gender)
                VALUES 
                ('UIA1B2C3', 'John Doe', 'john.doe@example.com', '81234567', 1),
                ('UID4E5F6', 'Jane Smith', 'jane.smith@example.com', '81234568', 2),
                ('UIG7H8I9', 'Alice Johnson', 'alice.johnson@example.com', '81234569', 2),
                ('UIJ1K2L3', 'Bob Brown', 'bob.brown@example.com', '81234570', 1),
                ('UIM4N5O6', 'Chris Lee', 'chris.lee@example.com', '81234571', 1),
                ('UIP7Q8R9', 'Sophia Taylor', 'sophia.taylor@example.com', '81234572', 2),
                ('UIS1T2U3', 'Daniel White', 'daniel.white@example.com', '81234573', 1),
                ('UIV4W5X6', 'Emma Davis', 'emma.davis@example.com', '81234574', 2),
                ('UIY7Z8A1', 'Michael Clark', 'michael.clark@example.com', '81234575', 1),
                ('UIB2C3D4', 'Olivia Lewis', 'olivia.lewis@example.com', '81234576', 2),
                ('UIE5F6G7', 'Ethan Hall', 'ethan.hall@example.com', '81234577', 1),
                ('UIH8I9J1', 'Isabella Adams', 'isabella.adams@example.com', '81234578', 2),
                ('UIK2L3M4', 'James Walker', 'james.walker@example.com', '81234579', 1),
                ('UIN5O6P7', 'Mia Robinson', 'mia.robinson@example.com', '81234580', 2),
                ('UIQ8R9S1', 'William Wright', 'william.wright@example.com', '81234581', 1);
            ");

            // Insert Employee Cafe Assignments with Past Dates
            migrationBuilder.Sql(@"
                INSERT INTO employee_cafe_assignments (employee_id, cafe_id, start_date)
                VALUES 
                ('UIA1B2C3', '11111111-1111-1111-1111-111111111111', '2022-05-15'),
                ('UID4E5F6', '11111111-1111-1111-1111-111111111111', '2021-11-10'),
                ('UIY7Z8A1', '11111111-1111-1111-1111-111111111111', '2020-12-24'),
                ('UIG7H8I9', '22222222-2222-2222-2222-222222222222', '2020-07-20'),
                ('UIJ1K2L3', '22222222-2222-2222-2222-222222222222', '2023-01-05'),
                ('UIB2C3D4', '22222222-2222-2222-2222-222222222222', '2019-02-14'),
                ('UIM4N5O6', '33333333-3333-3333-3333-333333333333', '2023-06-12'),
                ('UIP7Q8R9', '33333333-3333-3333-3333-333333333333', '2022-03-01'),
                ('UIS1T2U3', '44444444-4444-4444-4444-444444444444', '2022-08-25'),
                ('UIV4W5X6', '44444444-4444-4444-4444-444444444444', '2021-09-17');
            ");
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
