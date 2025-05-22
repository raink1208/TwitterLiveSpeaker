let observer = null;

function sendChatToApi(chatText) {
  fetch("http://localhost:5000/api/chat", {
    method: "POST",
    headers: {
      "Content-Type": "application/json"
    },
    body: JSON.stringify({ chat: chatText })
  })
  .then(response => response.text())
  .then(data => console.log("✅ APIレスポンス:", data))
  .catch(error => console.error("❌ POST失敗:", error));
}

function startMonitoring() {
  if (observer) return;

  observer = new MutationObserver((mutationsList) => {
    for (const mutation of mutationsList) {
      if (mutation.type === 'childList') {
        mutation.addedNodes.forEach((node) => {
          if (node.nodeType === Node.ELEMENT_NODE) {
            if (node.classList && node.classList.contains('r-1d5kdc7')) {
              const text = node.textContent.trim();
              if (text) {
                console.log('🆕 追加された .r-1d5kdc7 のテキスト:', text);
                sendChatToApi(text);
              }
            }
          }
        });
      }
    }
  });

  observer.observe(document.body, { childList: true, subtree: true });
  console.log('✅ 全体監視開始 (新規 .r-1d5kdc7 対象)');
}

function stopMonitoring() {
  if (observer) {
    observer.disconnect();
    observer = null;
    console.log('🛑 監視停止');
  }
}

chrome.runtime.onMessage.addListener((message, sender, sendResponse) => {
  if (message.type === 'START_MONITOR') {
    startMonitoring();
  } else if (message.type === 'STOP_MONITOR') {
    stopMonitoring();
  }
});

chrome.storage.local.get('monitoringEnabled', (data) => {
  if (data.monitoringEnabled) {
    setTimeout(startMonitoring, 2000);
  }
});