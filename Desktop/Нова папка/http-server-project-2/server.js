const http = require('http');
const fs = require('fs');
const path = require('path');

// Створення сервера
const server = http.createServer((req, res) => {
  console.log(`${req.method} ${req.url}`);

  // Маршрут для головної сторінки
  if (req.url === '/') {
    fs.readFile(path.join(__dirname, 'public', 'index.html'), 'utf-8', (err, data) => {
      if (err) {
        res.statusCode = 500;
        res.end('Помилка сервера');
        return;
      }
      res.statusCode = 200;
      res.setHeader('Content-Type', 'text/html');
      res.end(data);
    });
  }
  // Маршрут для стилів
  else if (req.url === '/styles.css') {
    fs.readFile(path.join(__dirname, 'public', 'styles.css'), 'utf-8', (err, data) => {
      if (err) {
        res.statusCode = 500;
        res.end('Помилка сервера');
        return;
      }
      res.statusCode = 200;
      res.setHeader('Content-Type', 'text/css');
      res.end(data);
    });
  }
  // Маршрут для POST-запиту на /data
  else if (req.url === '/data' && req.method === 'POST') {
    let body = '';
    req.on('data', chunk => {
      body += chunk;
    });
    req.on('end', () => {
      try {
        const jsonData = JSON.parse(body); // Парсимо отримані JSON-дані
        console.log(`Name: ${jsonData.name}, Age: ${jsonData.age}`);
        res.statusCode = 200;
        res.setHeader('Content-Type', 'application/json');
        res.end(JSON.stringify({
          message: 'Дані отримано успішно',
          receivedData: jsonData
        }));
      } catch (e) {
        res.statusCode = 400;
        res.end('Невірний формат JSON');
      }
    });
  }
  // Маршрут для GET-запиту на /disconnect
  else if (req.url === '/disconnect' && req.method === 'GET') {
    // Логіка для відключення користувача
    // Можна обробити запит, наприклад, сповіщаючи про успішне відключення
    console.log('Користувач відключений');
    res.statusCode = 200;
    res.setHeader('Content-Type', 'application/json');
    res.end(JSON.stringify({
      message: 'Користувач відключений від чату'
    }));
  }
  // Якщо не знайдено
  else {
    res.statusCode = 404;
    res.end('Не знайдено');
  }
});

// Налаштування порту
const PORT = process.env.PORT || 4000;
server.listen(PORT, () => {
  console.log(`Сервер запущений на http://localhost:${PORT}`);
});



