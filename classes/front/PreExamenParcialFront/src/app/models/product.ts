export interface Product {
  id: number;
  name: string;
  category: string;
  description: string;
  price: number;
  discount?: number;
  imageUrl: string;
  emoji: string;    // fallback when image fails to load
  gradient: string; // fallback background when image fails
  isNew?: boolean;
}
