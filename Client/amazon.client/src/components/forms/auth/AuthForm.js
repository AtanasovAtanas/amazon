import React, { Fragment, useState } from "react";
import identityService from "../../../services/identity";
import styles from "./AuthForm.module.css";
import { useLocation } from "react-router-dom";

const AuthForm = ({ title, description, buttonText, fields }) => {
	const [model, setModel] = useState({});

	const { pathname } = useLocation();

	const onChangeHandler = (event) => {
		const key = event.target.name.replace(" ", "").toLowerCase();
		const value = event.target.value;

		setModel({ ...model, [key]: value });
	};

	const onSubmitHandler = async (event) => {
		event.preventDefault();

		const type = pathname.substring(1).toUpperCase();

		await identityService.authenticate(
			type,
			model,
			(response) => console.log(response),
			() => console.log("authentication has failed")
		);
	};

	return (
		<div className={styles.root}>
			<div className={styles["image-wrapper"]}>
				<img
					src="https://upload.wikimedia.org/wikipedia/commons/thumb/a/a9/Amazon_logo.svg/1280px-Amazon_logo.svg.png"
					className={styles.logo}
					alt="Amazon"
				/>
			</div>
			<div className={styles["form-wrapper"]}>
				<form
					method="POST"
					onSubmit={(event) => onSubmitHandler(event)}
				>
					<div className={styles.container}>
						<h2>{title}</h2>
						<p>{description}</p>
						<hr />

						{fields.map((field) => {
							return (
								<Fragment key={field.value}>
									<label
										htmlFor={field.value}
										className={styles["auth-label"]}
									>
										{field.value}
									</label>
									<input
										className={styles["auth-input"]}
										type={field.type}
										placeholder={`Enter ${field.value}`}
										name={field.value}
										onChange={(event) =>
											onChangeHandler(event)
										}
									/>
								</Fragment>
							);
						})}

						<div className={styles.clearfix}>
							<button
								type="submit"
								className={styles["signup-btn"]}
							>
								{buttonText}
							</button>
						</div>
					</div>
				</form>
			</div>
		</div>
	);
};

export default AuthForm;
