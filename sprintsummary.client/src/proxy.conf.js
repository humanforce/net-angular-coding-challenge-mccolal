const PROXY_CONFIG = [
  {
    context: [
      "/publicholiday",
      "/jira",
      "/sprint",
      "/sprintcapacity"
    ],
    target: "https://localhost:7065",
    secure: false
  }
]

module.exports = PROXY_CONFIG; 
