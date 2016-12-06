$(function () {
	debugger;
	var chat = $.connection.cloudServicesHub;
	chat.client.updateResults = function (message) {
		$('#msg').text(htmlEncode(message));
	};
	$('#callService').focus();
	$.connection.hub.start().done(function () {
		$('#callService').click(function () {
			chat.server.callWebService($('#num').val());
		});
	});
});
// This optional function html-encodes messages for display in the page.
function htmlEncode(value) {
	var encodedValue = $('<div />').text(value).html();
	return encodedValue;
}