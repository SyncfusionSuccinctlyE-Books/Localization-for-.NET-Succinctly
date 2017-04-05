var MyPlugin = (function() {
	function checkName(name) {
		if (name === 'Jonas') {
			return 'Kungen';
		} else {
			return name;
		}
	}
	function MyPlugin()
	{
	}
	
	MyPlugin.prototype.print = function(name) {
		name = checkName(name);
		return  MyPlugin.Texts.Welcome.replace('{name}', name);
	}
	
	return MyPlugin;
})();

// Initialize default language.
if (!MyPlugin.Texts) {
	MyPlugin.Texts = {};
	MyPlugin.Texts.Welcome = 'Hello, {name} is in the house.';
}
