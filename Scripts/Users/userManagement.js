$(document).ready(function () {
  // Navigation and Section Toggle
  const $addUserLink = $('a:contains("Add Users")');
  const $allUsersLink = $('a:contains("All Users")');
  const $allAdminsLink = $('a:contains("Admins")');
  const $allManagersLink = $('a:contains("Managers")');
  const $allTeamMembersLink = $('a:contains("Team members")');
  const $allAdminsTable = $("#all-admins");
  const $allManagersTable = $("#all-managers");
  const $allTeamMembersTable = $("#all-teammembers");
  const $subSection1 = $("#sub-section-1");
  const $subSection2 = $("#sub-section-2");
  const $title1 = $("#title-1");
  const $title2 = $("#title-2");
  const $subTitle1 = $("#sub-title-1");
  const $hr = $subTitle1.next("hr");

  // Initialize with Add Users section visible
  $subSection1.show();
  $subSection2.hide();
  $title1.show();
  $title2.hide();
  $allAdminsTable.show();
  $allManagersTable.hide();
  $allTeamMembersTable.hide();

  // Handle All Admins click
  $allAdminsLink.click(function (e) {
    e.preventDefault();
    toggleSubSection("admins");
  });

  // Handle All Managers click
  $allManagersLink.click(function (e) {
    e.preventDefault();
    toggleSubSection("managers");
  });

  // Handle All Team Members click
  $allTeamMembersLink.click(function (e) {
    e.preventDefault();
    toggleSubSection("teammembers");
  });

  // Handle Add Users link click
  $addUserLink.click(function (e) {
    e.preventDefault();
    toggleSection("add");
  });

  // Handle All Users link click
  $allUsersLink.click(function (e) {
    e.preventDefault();
    toggleSection("all");
    // A function call to populate body of table with id : "all-users", Ignore the dummy data
  });

  // Function to toggle between Sub Sections
    function toggleSubSection(subSection) {

        if (subSection === "admins") {

            fetchAndPopulateAdmins();

    } else if (subSection === "managers") {
      $allAdminsTable.hide();
      $allManagersTable.show();
      $allTeamMembersTable.hide();

      $allAdminsLink.css({ "background-color": "#f7f5f7", color: "black" });
      $allManagersLink.css({ "background-color": "#2F2F31", color: "white" });
      $allTeamMembersLink.css({
        "background-color": "#f7f5f7",
        color: "black",
      });
    } else if (subSection === "teammembers") {
      $allAdminsTable.hide();
      $allManagersTable.hide();
      $allTeamMembersTable.show();

      $allAdminsLink.css({ "background-color": "#f7f5f7", color: "black" });
      $allManagersLink.css({ "background-color": "#f7f5f7", color: "black" });
      $allTeamMembersLink.css({
        "background-color": "#2F2F31",
        color: "white",
      });
    }
  }




    function fetchAndPopulateAdmins() {
        // Show the Admin table and hide others
        $allAdminsTable.show();
        $allManagersTable.hide();
        $allTeamMembersTable.hide();

        // Styling the links for active state
        $allAdminsLink.css({ "background-color": "#2F2F31", color: "white" });
        $allManagersLink.css({ "background-color": "#f7f5f7", color: "black" });
        $allTeamMembersLink.css({ "background-color": "#f7f5f7", color: "black" });

        // Fetch data for admin table using AJAX
        $.get("/Admin/GetAllAdmins", function (response) {
            if (response.success) {
                var tableBody = $("#all-admins tbody");
                tableBody.empty(); // Clear existing data in the table

                // Loop through the data and add rows to the table
                $.each(response.data, function (index, admin) {
                    var row = $("<tr>");

                    // Append data to each row and style with borders and center alignment
                    row.append("<td style='border: 1px solid #dddddd; text-align: center;'>" + (index + 1) + "</td>");
                    row.append("<td style='border: 1px solid #dddddd; text-align: center;'>" + admin.userName + "</td>");
                    row.append("<td style='border: 1px solid #dddddd; text-align: center;'>" + admin.email + "</td>");
                    row.append("<td style='border: 1px solid #dddddd; text-align: center;'>" + admin.password + "</td>");
                    row.append("<td style='border: 1px solid #dddddd; text-align: center;'>" +
                        "<img src='" + admin.profilePicPath + "' alt='Profile Picture' style='width: 50px; height: 50px; display: block; margin: 0 auto;'>"
                    ); // Center the image
                    row.append("<td style='border: 1px solid #dddddd; text-align: center;'>" + admin.adminType + "</td>");
                    row.append("<td style='border: 1px solid #dddddd; text-align: center;'>" + admin.roleDescription + "</td>");

                    // Adding operation links for Update and Delete
                    var operationLinks = `
                <td style='border: 1px solid #dddddd; text-align: center;'>
                    <a href='#' style='color:green' class='update-link' data-id='${admin.userName}'>Update</a> |
                    <a href='#' style='color:red' class='delete-link' data-id='${admin.userName}'>Delete</a>
                </td>
            `;
                    row.append(operationLinks); // Add the operation links to the row
                    tableBody.append(row);
                });

                // Event listener for delete link
                $(document).on('click', '.delete-link', function (e) {
                    e.preventDefault(); // Prevent the default action of the link

                    // Get the userName (ID) from the data-id attribute
                    var userName = $(this).data('id');
                    console.log(userName);
                    // Confirm deletion
                    if (confirm('Are you sure you want to delete this admin?')) {
                        // Send AJAX request to delete the admin
                        $.ajax({
                            url: '/Profile/DeleteUser',  // Your backend endpoint for deletion
                            type: 'DELETE',  // HTTP method for delete request
                            contentType: 'application/json', // Make sure content type is JSON
                            data: JSON.stringify(userName),  // Send userName in the body as JSON
                            success: function (response) {
                                if (response.success) {
                                    alert('Admin deleted successfully');
                                    // Optionally, remove the row from the table
                                    $('a[data-id="' + userName + '"]').closest('tr').remove();
                                } else {
                                    alert('Error: ' + response.message);
                                }
                            },
                            error: function (xhr, status, error) {
                                console.error('Error occurred while deleting admin:', error);
                                alert('An error occurred while deleting the admin.');
                            }
                        });
                    }
                });

            }
        });
    }


    
  // Function to toggle between Add Users and All Users sections
  function toggleSection(section) {
    if (section === "add") {
      $addUserLink.css({ "background-color": "#2F2F31", color: "white" });
      $allUsersLink.css({ "background-color": "white", color: "black" });
      $subSection1.show();
      $subSection2.hide();
      $title1.show();
      $title2.hide();
      $subTitle1.show();
      $hr.show();
    } else if (section === "all") {
      $allUsersLink.css({ "background-color": "#2F2F31", color: "white" });
      $addUserLink.css({ "background-color": "white", color: "black" });
      $subSection1.hide();
      $subSection2.show();
      $title1.hide();
      $title2.show();
      $subTitle1.hide();
      $hr.hide();
    }
  }

  // Dynamic Fields for User Type
  const $userTypeSelect = $("#usertype");
  const $dynamicFields = $("#dynamicFields");

  // Handle user type change
  $userTypeSelect.on("change", updateForm);

  // Function to update form based on user type
  function updateForm() {
    const userType = $userTypeSelect.val();
    $dynamicFields.empty();

    const fieldStyle =
      "display: flex; flex-direction: column; margin-bottom: 15px;";
    const labelStyle = "margin-bottom: 5px;";
    const inputStyle =
      "padding: 8px; border: 1px solid #ddd; border-radius: 4px; font-size: 16px;";

    if (userType === "admin") {
      $dynamicFields.append(`
                <div style="${fieldStyle}">
                    <label for="adminType" style="${labelStyle}">Admin Type</label>
                    <select id="adminType" name="AdminType" required style="${inputStyle}">
                        <option value="primary">Primary</option>
                        <option value="secondary">Secondary</option>
                    </select>
                </div>
                <div style="${fieldStyle}">
                    <label for="roleDescription" style="${labelStyle}">Role Description</label>
                    <input type="text" id="roleDescription" name="RoleDescription" required style="${inputStyle}">
                </div>
            `);
    } else if (userType === "manager") {
      $dynamicFields.append(`
                <div style="${fieldStyle}">
                    <label for="domain" style="${labelStyle}">Domain</label>
                    <input type="text" id="domain" name="Domain" required style="${inputStyle}">
                </div>
                <div style="${fieldStyle}">
                    <label for="experience" style="${labelStyle}">Experience in Years</label>
                    <input type="number" id="experience" name="Experience" required style="${inputStyle}">
                </div>
                <div style="${fieldStyle}">
                    <label for="yearlyPay" style="${labelStyle}">Yearly Pay</label>
                    <input type="number" id="yearlyPay" name="YearlyPay" required style="${inputStyle}">
                </div>
                <div style="${fieldStyle}">
                    <label for="department" style="${labelStyle}">Department</label>
                    <select id="department" name="Department" required style="${inputStyle}">
                        <!-- Department options will be populated via AJAX -->
                    </select>
                </div>
            `);

      // Fetch departments using AJAX
      $.get("/Department/GetDepartments", function (data) {
        var departmentDropdown = $("#department");
        departmentDropdown.empty();
        departmentDropdown.append(
          '<option value="">Select Department</option>'
        );
        $.each(data, function (_, item) {
          departmentDropdown.append(
              '<option value="' + item.Name + '">' + item.Name + "</option>"
          );
        });
      });
    } else if (userType === "team-member") {
      $dynamicFields.append(`
                <div style="${fieldStyle}">
                    <label for="rank" style="${labelStyle}">Rank</label>
                    <input type="number" id="rank" name="Rank" required style="${inputStyle}">
                </div>
                <div style="${fieldStyle}">
                    <label for="monthlyPay" style="${labelStyle}">Monthly Pay</label>
                    <input type="number" id="monthlyPay" name="MonthlyPay" required style="${inputStyle}">
                </div>
                <div style="${fieldStyle}">
                    <label for="workHours" style="${labelStyle}">Work Hours/Week</label>
                    <input type="number" id="workHours" name="WorkHours" required style="${inputStyle}">
                </div>
                <div style="${fieldStyle}">
                    <label for="teamMemberDepartment" style="${labelStyle}">Department</label>
                    <select id="teamMemberDepartment" name="TeamMemberDepartment" required style="${inputStyle}">
                        <!-- Department options will be populated via AJAX -->
                    </select>
                </div>
                <div style="${fieldStyle}">
                    <label for="manager" style="${labelStyle}">Manager</label>
                    <select id="manager" name="Manager" required style="${inputStyle}">
                        <!-- Manager options will be populated via AJAX -->
                    </select>
                </div>
                <div style="${fieldStyle}">
                    <label for="team" style="${labelStyle}">Team</label>
                    <select id="team" name="Team" required style="${inputStyle}">
                        <!-- Team options will be populated via AJAX -->
                    </select>
                </div>
            `);

      // Fetch departments using AJAX
      $.get("/Department/GetDepartments", function (data) {
        var departmentDropdown = $("#teamMemberDepartment");
        departmentDropdown.empty();
        departmentDropdown.append(
          '<option value="">Select Department</option>'
        );
        $.each(data, function (index, item) {
          departmentDropdown.append(
              '<option value="' + item.Name + '">' + item.Name + "</option>"
          );
        });
      });

      // Fetch managers using AJAX
      $.get("/Manager/GetManagers", function (data) {
        var managerDropdown = $("#manager");
        managerDropdown.empty();
        managerDropdown.append('<option value="">Select Manager</option>');
        $.each(data, function (index, item) {
          managerDropdown.append(
            '<option value="' + item.Text + '">' + item.Text + "</option>"
          );
        });
      });

      // Fetch teams using AJAX
      $.get("/Team/GetTeams", function (data) {
        var teamDropdown = $("#team");
        teamDropdown.empty();
        teamDropdown.append('<option value="">Select Team</option>');
        $.each(data, function (index, item) {
          teamDropdown.append(
            '<option value="' + item.Text + '">' + item.Text + "</option>"
          );
        });
      });
    }
  }

  // Form submission handler
  $("#userForm").on("submit", function () {
    // Log form values to the console for debugging
    console.log("UserType:", $("#usertype").val());
    console.log("Email:", $("#email").val());
    console.log("Password:", $("#password").val());
    console.log("Username:", $("#username").val());

    // Collect the common form data
    var formData = {
      userType: $("#usertype").val(),
      email: $("#email").val(),
      password: $("#password").val(),
      username: $("#username").val(),
    };

    // Add the manager-specific data only if the user type is 'manager'
    if ($("#usertype").val() === "manager") {
      formData.domain = $("#domain").val();
      formData.experience = $("#experience").val();
      formData.yearlyPay = $("#yearlyPay").val();
      formData.department = $("#department").val();

      console.log("Domain:", formData.domain);
      console.log("Experience (Years):", formData.experience);
      console.log("Yearly Pay:", formData.yearlyPay);
      console.log("Department:", formData.department);
    }

    // Add the team-member-specific data if the user type is 'team-member'
    if (formData.userType === "team-member") {
      formData.rank = $("#rank").val();
      formData.monthlyPay = $("#monthlyPay").val();
      formData.workHours = $("#workHours").val();
      formData.department = $("#teamMemberDepartment").val();
      formData.manager = $("#manager").val();
      formData.team = $("#team").val();

      // Log team-member-specific fields to the console
      console.log("Rank:", formData.rank);
      console.log("Monthly Pay:", formData.monthlyPay);
      console.log("Work Hours (Weekly):", formData.workHours);
      console.log("Department (Team Member):", formData.department);
      console.log("Manager:", formData.manager);
      console.log("Team:", formData.team);
    }

    console.log("Form Data:", formData);

    // Perform AJAX POST request to the server with form data
    $.ajax({
      url: "/Profile/AddProfile", // The URL of your controller action
      type: "POST",
      data: formData, // Send the form data to the server
      success: function () {
        console.log("Form successfully submitted!");
        // Handle success (you can redirect, show a message, etc.)
      },
      error: function (_, __, error) {
        console.log("Error occurred while submitting the form:", error);
        // Handle error (you can show an error message to the user)
      },
    });
  });
});
