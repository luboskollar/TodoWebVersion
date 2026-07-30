function loadTodos(status = null) {
    const url = status === null ? 'api/Todo' : 'api/Todo/status/' + status;
    fetch(url)
        .then(res => res.json())
        .then(data => {
            const todoList = document.getElementById('todo-list');
            todoList.innerHTML = '';
            data.forEach(todo => {
                const listItem = document.createElement('li');
                listItem.textContent = todo.title;
                
                if (todo.status === 2) {
                    listItem.classList.add('completed');
                }
                
                const deleteButton = document.createElement('button');
                deleteButton.textContent = "x";
                deleteButton.addEventListener('click', () => {
                    fetch(`api/Todo/${todo.id}`, {
                        method: 'DELETE',
                    })
                        .then(() => {
                            loadTodos();
                        })
                })

                const toggleButton = document.createElement('button');
                toggleButton.textContent = todo.status === 2 ? "[x]" : "[ ]";
                toggleButton.addEventListener('click', () => {
                    fetch(`api/Todo/${todo.id}`, {
                        method: 'PUT',
                        headers: {'Content-Type': 'application/json'},
                        body: JSON.stringify({
                            title: todo.title,
                            dueDate: todo.dueDate,
                            priority: todo.priority,
                            status: todo.status === 2 ? 0 : 2
                        })
                    })
                        .then(() => {
                            loadTodos();
                        });
                });
                listItem.appendChild(toggleButton);
                listItem.appendChild(deleteButton);
                todoList.appendChild(listItem);
            });
            
            const counter = document.getElementById('task-counter');
            counter.textContent = `${data.filter(todo => todo.status === 2).length} / ${data.length}`;
        });
}

loadTodos();

document.getElementById('add-btn').addEventListener('click', function(){
    const input = document.getElementById('new-task');
    const error = document.getElementById('error-message');
    const dateInput = document.getElementById('new-date');
    if (input.value.trim() === '' || dateInput.value.trim() === '') {
        error.textContent = '> error: title and date required';
        return;
    }
    fetch('api/Todo', {
        method: 'POST',
        headers: {'Content-Type': 'application/json'},
        body: JSON.stringify({
            title: input.value,
            dueDate: dateInput.value,
            priority: Number(document.getElementById('new-priority').value),
        })
    })
        .then(() => {
            input.value = '';
            error.textContent = '';
            loadTodos();
        });
})

document.getElementById('filter-all').addEventListener('click', function(){
    loadTodos();
})
document.getElementById('filter-pending').addEventListener('click', function(){
    loadTodos(0);
})
document.getElementById('filter-completed').addEventListener('click', function(){
    loadTodos(2);
})