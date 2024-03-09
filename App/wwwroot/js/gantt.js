let $tareas = document.querySelector('#jsonTareas')

let tasks = JSON.parse($tareas.value)

var gantt = new Gantt("#gantt", tasks, {
    view_modes: ['Quarter Day', 'Half Day', 'Day', 'Week', 'Month'],
    view_mode: 'Day',
    language: 'es',
    custom_popup_html: null,    
    on_date_change: function (task, start, end) {
        console.log(task, start, end);
    }    
})

function ChangeViewMode(mode) {
    gantt.change_view_mode(mode)
}