import http from 'k6/http';

export default function () {
  const res = http.post(
    'https://toolforge-agent.onrender.com/api/chat',
    JSON.stringify({
      message: 'What time is it in Tokyo?'
    }),
    {
      headers: {
        'Content-Type': 'application/json'
      }
    }
  );

  console.log(
    `Status: ${res.status}`
  );
}