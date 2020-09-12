import React, { useRef, useState } from "react";
import ChevronLeftIcon from "@material-ui/icons/ChevronLeft";
import ChevronRightIcon from "@material-ui/icons/ChevronRight";
import styles from "./Gallery.module.css";
import Lightbox from "../lightbox/Lightbox";

const Gallery = ({ images, alt }) => {
	const [featured, setFeatured] = useState(images[0]);
	const [isModalOpen, setIsModalOpen] = useState(false);
	const toggleModal = () => setIsModalOpen(!isModalOpen);

	const sliderRef = useRef(null);

	const onClickHandler = (event) => setFeatured(event.target.src);

	const scrollLeft = () => {
		sliderRef.current.scrollLeft -= 110;
	};

	const scrollRight = () => {
		sliderRef.current.scrollLeft += 110;
	};

	return (
		<>
			<img
				className={styles.featured}
				src={featured}
				onClick={toggleModal}
				alt={alt}
			/>
			<div className={styles.wrapper}>
				<ChevronLeftIcon
					className={styles.arrow}
					fontSize="large"
					onClick={scrollLeft}
				/>
				<div className={styles.slider} ref={sliderRef}>
					{images.map((image, index) => {
						const isActive = image === featured;
						return (
							<img
								key={index}
								className={
									isActive ? styles.active : styles.picture
								}
								src={image}
								alt={alt}
								onClick={(event) => onClickHandler(event)}
							/>
						);
					})}
				</div>
				<ChevronRightIcon
					className={styles.arrow}
					fontSize="large"
					onClick={scrollRight}
				/>
			</div>
			{isModalOpen ? (
				<Lightbox
					featured={featured}
					images={images}
					alt={alt}
					closeHandler={toggleModal}
				/>
			) : null}
		</>
	);
};

export default Gallery;
