document.addEventListener('DOMContentLoaded', () => {
  const btn = document.getElementById('toggleBtn');

  chrome.storage.local.get('monitoringEnabled', (data) => {
    btn.textContent = data.monitoringEnabled ? '監視停止' : '監視開始';
  });

  btn.addEventListener('click', () => {
    chrome.storage.local.get('monitoringEnabled', (data) => {
      const newState = !data.monitoringEnabled;
      chrome.storage.local.set({ monitoringEnabled: newState }, () => {
        btn.textContent = newState ? '監視停止' : '監視開始';

        // 現在のタブにメッセージ送信
        chrome.tabs.query({ active: true, currentWindow: true }, (tabs) => {
          chrome.tabs.sendMessage(tabs[0].id, {
            type: newState ? 'START_MONITOR' : 'STOP_MONITOR'
          });
        });
      });
    });
  });
});
