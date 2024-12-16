document.querySelector('form').addEventListener('submit', function(event) {
    event.preventDefault(); // Забороняємо стандартну відправку форми
    
    const name = document.getElementById('name').value;
    const age = document.getElementById('age').value;
  
    const data = { name: name, age: age };
  
    // Відправляємо POST-запит
    fetch('/data', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(data), // Перетворюємо об'єкт в JSON
    })
    .then(response => response.json())
    .then(data => {
      console.log('Дані отримано успішно:', data);
  
      // Виводимо повідомлення на сторінку
      const messageDiv = document.createElement('div');
      messageDiv.textContent = `Дякуємо за відправку даних! Ім'я: ${data.receivedData.name}, Вік: ${data.receivedData.age}`;
      messageDiv.style.color = 'green'; // Змінюємо колір тексту на зелений
      document.body.appendChild(messageDiv);
      
      // Додаємо кнопку "Відключитися"
      const disconnectButton = document.createElement('button');
      disconnectButton.textContent = 'Відключитися';
      document.body.appendChild(disconnectButton);
  
      // Слухаємо подію відключення
      disconnectButton.addEventListener('click', function() {
        // Відправляємо запит на відключення
        fetch('/disconnect', {
          method: 'GET',
          headers: {
            'User-Id': name, // або якийсь інший ідентифікатор
          }
        })
        .then(response => response.json())
        .then(data => {
          alert('Ви відключилися від чату');
          
          // Блокуємо можливість відправлення нових повідомлень
          document.querySelector('input[type="text"]').disabled = true;
          document.querySelector('input[type="number"]').disabled = true;
          document.querySelector('button[type="submit"]').disabled = true;
        })
        .catch(error => console.error('Помилка при відключенні:', error));
      });
    })
    .catch(error => {
      console.error('Помилка:', error);
    });
  });
  
  