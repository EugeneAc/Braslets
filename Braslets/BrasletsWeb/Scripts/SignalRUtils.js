$(function () {
    // Ссылка на автоматически-сгенерированный прокси хаба
    var hub = $.connection.brasletHub;
    // Объявление функции, которая хаб вызывает при получении сообщений
    hub.client.addMessage = function (tag, value) {
        alert(tag + ' - ' + value);
    };

    // Открываем соединение
    $.connection.hub.start();

    });
});