$(document).ready(function () {
    // Navigation and Section Toggle
    const $addDepartmentLink = $('a:contains("Add Department")');
    const $allDepartmentsLink = $('a:contains("All Departments")');
    const $subSection1 = $('#sub-section-1');
    const $subSection2 = $('#sub-section-2');
    const $title1 = $('#title-1');
    const $title2 = $('#title-2');
    const $subTitle1 = $('#sub-title-1');
    const $hr = $subTitle1.next('hr');

    // Initialize with Add Department section visible
    $subSection1.show();
    $subSection2.hide();
    $title1.show();
    $title2.hide();

    $addDepartmentLink.click(function (e) {
        e.preventDefault();
        toggleSection('add');
    });

    $allDepartmentsLink.click(function (e) {
        e.preventDefault();
        toggleSection('all');
    });

    function toggleSection(section) {
        if (section === 'add') {
            $addDepartmentLink.css({ 'background-color': '#2F2F31', color: 'white' });
            $allDepartmentsLink.css({ 'background-color': 'white', color: 'black' });
            $subSection1.show();
            $subSection2.hide();
            $title1.show();
            $title2.hide();
            $subTitle1.show();
            $hr.show();
        } else if (section === 'all') {
            $allDepartmentsLink.css({ 'background-color': '#2F2F31', color: 'white' });
            $addDepartmentLink.css({ 'background-color': 'white', color: 'black' });
            $subSection1.hide();
            $subSection2.show();
            $title1.hide();
            $title2.show();
            $subTitle1.hide();
            $hr.hide();
        }
    }

});
