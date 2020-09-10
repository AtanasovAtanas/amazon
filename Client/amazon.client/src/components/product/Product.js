import React from "react";
import styles from "./Product.module.css";
import { Link } from "react-router-dom";

const Product = ({ imgSrc, title, price }) => {
	return (
		<div class={styles.card}>
			<img src={imgSrc} alt="Product image" />
			<h3>{title}</h3>
			<p class={styles.price}>${price.toFixed(2)}</p>
			<Link to="#">See product details</Link>
		</div>
	);
};

export default Product;
