function showAlert(message, type = 'danger', timeout = 3000) {
    const alertContainer = document.querySelector('.alert-container') || createAlertContainer();
    const alert = document.createElement('div');
    alert.className = `alert alert-${type} alert-dismissible fade show`;
    alert.innerText = message;

    const closeButton = document.createElement('button');
    closeButton.type = 'button';
    closeButton.className = 'btn-close';
    closeButton.setAttribute('aria-label', 'Close');
    closeButton.onclick = () => alert.remove();

    alert.appendChild(closeButton);
    alertContainer.appendChild(alert);

    let timeoutId;
    let remainingTime = timeout;
    let startTime = Date.now();

    const startTimeout = () => {
        timeoutId = setTimeout(() => {
            alert.style.opacity = 0;
            setTimeout(() => alert.remove(), 500);
        }, remainingTime);
    };

    const pauseTimeout = () => {
        clearTimeout(timeoutId);
        remainingTime -= Date.now() - startTime;
    };

    alert.addEventListener('mouseenter', pauseTimeout);
    alert.addEventListener('mouseleave', () => {
        startTime = Date.now();
        startTimeout();
    });

    setTimeout(() => {
        alert.style.display = 'block';
        alert.style.opacity = 1;
        startTimeout();
    }, 100);

    function createAlertContainer() {
        const container = document.createElement('div');
        container.className = 'alert-container';
        container.style.position = 'fixed';
        container.style.top = '20px';
        container.style.right = '20px';
        container.style.zIndex = '1050';
        container.style.maxWidth = '500px';

        document.body.appendChild(container);
        return container;
    }
}