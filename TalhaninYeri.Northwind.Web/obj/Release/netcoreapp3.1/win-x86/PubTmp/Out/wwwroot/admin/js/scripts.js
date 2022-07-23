/*!
    * Start Bootstrap - SB Admin v7.0.3 (https://startbootstrap.com/template/sb-admin)
    * Copyright 2013-2021 Start Bootstrap
    * Licensed under MIT (https://github.com/StartBootstrap/startbootstrap-sb-admin/blob/master/LICENSE)
    */
    // 
// Scripts
// 

window.addEventListener('DOMContentLoaded', event => {

    // Toggle the side navigation
    const sidebarToggle = document.body.querySelector('#sidebarToggle');
    if (sidebarToggle) {
        // Uncomment Below to persist sidebar toggle between refreshes
        // if (localStorage.getItem('sb|sidebar-toggle') === 'true') {
        //     document.body.classList.toggle('sb-sidenav-toggled');
        // }
        sidebarToggle.addEventListener('click', event => {
            event.preventDefault();
            document.body.classList.toggle('sb-sidenav-toggled');
            localStorage.setItem('sb|sidebar-toggle', document.body.classList.contains('sb-sidenav-toggled'));
        });
    }

});

document.querySelectorAll(".price").forEach(item => {
    item.textContent = item.textContent.slice(0, -2);
});

jQuery.extend(jQuery.fn.dataTableExt.oSort, {
    "currency-pre": function (a) {
        a = (a === "-") ? 0 : a.replace(/[^\d\-\.]/g, "");
        return parseFloat(a);
    },

    "currency-asc": function (a, b) {
        return a - b;
    },

    "currency-desc": function (a, b) {
        return b - a;
    }
});

$(document).ready(function () {
    $('#OrdersDT').DataTable({
        "order": [[5,"desc"]],
        columnDefs: [
            { type: 'currency', targets: [6] },
            { 'orderable': false, targets: [7,8] }
        ],
        language: {
            url: '//cdn.datatables.net/plug-ins/1.10.25/i18n/Turkish.json'
        }
    });

    $('#OrderHistoryDT').DataTable({
        "order": [[6, "desc"]],
        columnDefs: [
            { type: 'currency', targets: [7] },
            { 'orderable': false, targets: [8] }
        ],
        language: {
            url: '//cdn.datatables.net/plug-ins/1.10.25/i18n/Turkish.json'
        }
    });

    $('#productDT').DataTable({
        "order": [[5, "desc"]],
        columnDefs: [
            { type: 'currency', targets: [3] },
            { 'orderable': false, targets: [0,6,7] }
        ],
        language: {
            url: '//cdn.datatables.net/plug-ins/1.10.25/i18n/Turkish.json'
        }
    });

    $('#sliderDT').DataTable({
        "order": [[3, "asc"]],
        columnDefs: [
            { 'orderable': false, targets: [0, 4, 5] }
        ],
        language: {
            url: '//cdn.datatables.net/plug-ins/1.10.25/i18n/Turkish.json'
        }
    });

    $('#usersDT').DataTable({
        "order": [[1, "asc"]],
        language: {
            url: '//cdn.datatables.net/plug-ins/1.10.25/i18n/Turkish.json'
        }
    });
});


