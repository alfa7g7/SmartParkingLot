const express = require('express');
const app = express();
const port = 5000;

// ...existing code...

app.get('/', (req, res) => {
  res.send('Hello World!');
});

// ...existing code...

app.listen(port, () => {
  console.log(`Server is running on http://localhost:${port}`);
});
