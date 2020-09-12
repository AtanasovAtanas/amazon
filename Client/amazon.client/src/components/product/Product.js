import React from "react";
import styles from "./Product.module.css";
import { Link } from "react-router-dom";

const Product = ({ imgSrc, id, slug, title, price }) => {
	const linkTo = `/products/${id}/${slug}`;

	return (
		<div className={styles.card}>
			<img src={imgSrc} alt={title} />
			<h3>{title}</h3>
			<p className={styles.price}>${price.toFixed(2)}</p>
			<Link to={linkTo}>See product details</Link>
		</div>
	);
};

export default Product;
