function loadTodos() {
    fetch('api/Todo')
        .then(res => res.json())
        .then(data => {
            const todoList = document.getElementById('todo-list');
            todoList.innerHTML = '';
            data.forEach(todo => {
                const listItem = document.createElement('li');
                listItem.textContent = todo.title;
                todoList.appendChild(listItem);
            });
        });
}

loadTodos();

document.getElementById('add-btn').addEventListener('click', function(){
    const input = document.getElementById('new-task');
    fetch('api/Todo', {
        method: 'POST',
        headers: {'Content-Type': 'application/json'},
        body: JSON.stringify({
            title: input.value,
            dueDate: new Date().toISOString(),
            priority: 0
        })
    })
        .then(() => {
            input.value = '';
            loadTodos();
        });
})