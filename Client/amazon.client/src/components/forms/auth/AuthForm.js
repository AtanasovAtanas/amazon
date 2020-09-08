import React, { Fragment } from "react";
import styles from "./AuthForm.module.css";

const AuthForm = ({ title, description, buttonText, fields }) => {
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
				<form>
					<div className={styles.container}>
						<h2>{title}</h2>
						<p>{description}</p>
						<hr />

						{fields.map((field) => {
							return (
								<Fragment key={field.value}>
									<label
										htmlFor={field.value}
										className={styles["field-label"]}
									>
										{field.value}
									</label>
									<input
										type={field.type}
										placeholder={`Enter ${field.value}`}
										name={field.value}
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
