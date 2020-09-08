import React from "react";
import AuthForm from "../../components/forms/auth/AuthForm";

const LoginPage = () => {
	return (
		<AuthForm
			title="Login"
			description="Please fill in this form to login in your account."
			buttonText="Login"
			fields={[
				{ value: "Email", type: "text" },
				{ value: "Password", type: "password" },
			]}
		/>
	);
};

export default LoginPage;
