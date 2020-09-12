import React, { useState } from "react";
import styles from "./Lightbox.module.css";

const Lightbox = ({ featured, images, alt, closeHandler }) => {
	const [main, setMain] = useState(featured);
	const [index, setIndex] = useState(images.indexOf(featured));

	const goToPrevImage = () => {
		const nextIndex = index - 1 < 0 ? 0 : index - 1;
		setIndex(nextIndex);
		setMain(images[nextIndex]);
	};

	const goToNextImage = () => {
		const nextIndex =
			index + 1 >= images.length ? images.length - 1 : index + 1;

		setIndex(nextIndex);
		setMain(images[nextIndex]);
	};

	return (
		<div className={styles.modal}>
			<span className={styles.close} onClick={closeHandler}>
				&times;
			</span>
			<div className={styles["modal-content"]}>
				<div>
					<img
						className={styles["modal-main-image"]}
						src={main}
						alt={alt}
					/>
				</div>

				<span
					className={`${styles.prev} ${
						index === 0 ? styles.disabled : ""
					}`}
					onClick={goToPrevImage}
				>
					&#10094;
				</span>
				<span
					className={`${styles.next} ${
						index === images.length - 1 ? styles.disabled : ""
					}`}
					onClick={goToNextImage}
				>
					&#10095;
				</span>

				<div className={styles.row}>
					{images.map((image, index) => (
						<div key={index} className={styles.column}>
							<img
								className={
									image === main ? styles.active : styles.demo
								}
								src={image}
								alt={alt}
								onClick={() => {
									setIndex(index);
									setMain(image);
								}}
							/>
						</div>
					))}
				</div>
			</div>
		</div>
	);
};

export default Lightbox;
