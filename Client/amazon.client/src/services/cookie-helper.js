const getCurrentBearerToken = () => {
	let result = "";

	const cookies = document.cookie.split("; ");

	cookies.forEach((cookie) => {
		const parts = cookie.split("=");
		const name = parts[0];

		if (name === "Bearer") {
			const value = parts[1];
			result = `Bearer ${value}`;
			return;
		}
	});

	return result ? result : null;
};

export default getCurrentBearerToken;
