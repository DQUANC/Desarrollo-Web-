import styles from './LoadingGrid.module.css'

const SKELETON_COUNT = 12

export function LoadingGrid() {
  return (
    <div className={styles.grid} aria-busy="true" aria-label="Loading countries">
      {Array.from({ length: SKELETON_COUNT }).map((_, i) => (
        <div key={i} className={styles.card}>
          <div className={styles.flag} />
          <div className={styles.body}>
            <div className={styles.title} />
            <div className={styles.line} />
            <div className={styles.line} />
            <div className={styles.lineShort} />
          </div>
        </div>
      ))}
    </div>
  )
}
