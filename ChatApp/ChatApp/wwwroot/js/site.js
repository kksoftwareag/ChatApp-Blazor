window.ChatApp = {
    SetUsername: function (username) {
        localStorage.setItem('username', username);
    },
    GetUsername: function () {
        return localStorage.getItem('username');
    },
    ScrollToBottom: function () {
        let chatlog = document.querySelector('.chatlog');
        let lastChild = chatlog.lastChild;

        if (lastChild) {
            lastChild.scrollIntoView();
        }
    }
};
