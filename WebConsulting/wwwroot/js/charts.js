// Функция для создания различных типов графиков
window.renderChart = function (canvasId, chartType, title, labels, data, backgroundColors) {
    const canvas = document.getElementById(canvasId);
    if (!canvas) {
        console.error(`Canvas element with id ${canvasId} not found`);
        return null;
    }

    const ctx = canvas.getContext('2d');
    ctx.clearRect(0, 0, canvas.width, canvas.height);

    const config = {
        type: chartType,
        data: {
            labels: labels,
            datasets: [{
                label: title,
                data: data,
                backgroundColor: backgroundColors,
                borderColor: backgroundColors.map(color => color.replace('0.8', '1')),
                borderWidth: 1
            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            plugins: {
                legend: {
                    position: 'right',
                },
                title: {
                    display: true,
                    text: title,
                    font: {
                        size: 16
                    }
                },
                tooltip: {
                    callbacks: {
                        label: function (context) {
                            let label = context.dataset.label || '';
                            if (label) {
                                label += ': ';
                            }
                            label += context.raw;
                            return label;
                        }
                    }
                }
            }
        }
    };

    return new Chart(ctx, config);
};

window.renderLineChart = function (canvasId, title, labels, data, color) {
    const canvas = document.getElementById(canvasId);
    if (!canvas) {
        console.error(`Canvas element with id ${canvasId} not found`);
        return null;
    }

    const ctx = canvas.getContext('2d');
    ctx.clearRect(0, 0, canvas.width, canvas.height);

    const baseColor = color.includes('rgba') ?
        color.substring(0, color.lastIndexOf(',')) + ')' :
        color;

    const gradient = ctx.createLinearGradient(0, 0, 0, 400);
    gradient.addColorStop(0, baseColor.replace(')', ', 0.8)'));
    gradient.addColorStop(1, baseColor.replace(')', ', 0.1)'));

    const config = {
        type: 'line',
        data: {
            labels: labels,
            datasets: [{
                label: title,
                data: data,
                backgroundColor: gradient,
                borderColor: color,
                tension: 0.3,
                fill: true,
                pointBackgroundColor: color,
                pointBorderColor: '#fff',
                pointHoverRadius: 5
            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            plugins: {
                title: {
                    display: true,
                    text: title,
                    font: {
                        size: 16
                    }
                }
            },
            scales: {
                y: {
                    beginAtZero: true,
                    grid: {
                        display: true,
                        color: "rgba(0, 0, 0, 0.05)"
                    }
                },
                x: {
                    grid: {
                        display: false
                    }
                }
            }
        }
    };

    return new Chart(ctx, config);
};

window.destroyChart = function (canvasId) {
    const canvas = document.getElementById(canvasId);
    if (!canvas) return;

    const chart = Chart.getChart(canvas);
    if (chart) {
        try {
            chart.destroy();
        } catch (e) {
            console.error(`Error destroying chart on ${canvasId}:`, e);
        }
    }

    const ctx = canvas.getContext('2d');
    ctx.clearRect(0, 0, canvas.width, canvas.height);
};