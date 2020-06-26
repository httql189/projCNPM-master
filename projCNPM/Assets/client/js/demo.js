'use strict';

// Written using ES5 JS for browser support
window.addEventListener('DOMContentLoaded', function () {
	var form = document.querySelector('form');

	form.addEventListener('submit', function (e) {
		e.preventDefault();

		// Form elements
		var title = "Thông báo";
		var message = "Xác nhận thành công!";
		var position = "Top Right";
		var duration = form.querySelector('#duration').value;
		var theme = "Success";
		var closeOnClick = form.querySelector('#close').checked;
		var displayClose = form.querySelector('#closeButton').checked;

		if(!message) {
			message = 'You did not enter a message...';
		}

		window.createNotification({
			closeOnClick: closeOnClick,
			displayCloseButton: displayClose,
			positionClass: position,
			showDuration: duration,
			theme: theme
		})({
			title: title,
			message: message
		});
	});
});