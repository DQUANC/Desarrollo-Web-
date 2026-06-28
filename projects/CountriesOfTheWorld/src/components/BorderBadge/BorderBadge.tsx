import { Link } from 'react-router-dom'
import styles from './BorderBadge.module.css'

interface BorderBadgeProps {
  name: string
  cca3: string
}

export function BorderBadge({ name, cca3 }: BorderBadgeProps) {
  return (
    <Link to={`/country/${cca3}`} className={styles.badge}>
      {name}
    </Link>
  )
}
