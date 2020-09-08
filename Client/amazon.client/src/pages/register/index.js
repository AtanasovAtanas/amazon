import React from "react";
import AuthForm from "../../components/forms/auth/AuthForm";

const RegisterPage = () => {
	return (
		<AuthForm
			title="Creater your account"
			description="Please fill in this form to create an account."
			buttonText="Register"
			fields={[
				{ value: "Email", type: "text" },
				{ value: "Password", type: "password" },
				{ value: "Repeat Password", type: "password" },
			]}
		/>
	);
};

export default RegisterPage;
