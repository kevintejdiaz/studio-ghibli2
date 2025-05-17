document.addEventListener('DOMContentLoaded', () => {
  const hero   = document.querySelector('.hero');
  const slides = hero.querySelectorAll('.slide');
  let current   = 0;  // Empieza en el primer slide

  function updateHero() {
    // 1) Activar sólo el slide actual
    slides.forEach(s => s.classList.remove('active'));
    slides[current].classList.add('active');

    // 2) Propagar la clase fondoX desde el slide activo al .hero
    //    - Eliminamos cualquier clase que empiece por "fondo"
    hero.classList.forEach(c => {
      if (c.startsWith('fondo')) hero.classList.remove(c);
    });
    //    - Añadimos la clase "fondoX" del slide activo
    slides[current].classList.forEach(c => {
      if (c.startsWith('fondo')) hero.classList.add(c);
    });
  }

  // 3) Arrancamos el auto‐slide y guardamos el ID
  const intervalId = setInterval(() => {
    current = (current +1) % slides.length;
    updateHero();
  }, 10000);

  // 4) Función para detener el auto‐slide
  function stopHeroAuto() {
    clearInterval(intervalId);
    console.log('Auto‐slide detenido');
  }

  // 5) Función para ir a un slide concreto y detener auto‐slide
  function goToHeroSlide(index) {
    if (index >= 0 && index < slides.length) {
      stopHeroAuto();
      current = index;
      updateHero();
      console.log(`Slide cambiado manualmente a índice ${index}`);
    } else {
      console.warn(`Índice fuera de rango: debe ser entre 0 y ${slides.length - 1}`);
    }
  }

  // 6) Exponemos las funciones en window para poder llamarlas desde la consola
  window.stopHeroAuto   = stopHeroAuto;
  window.goToHeroSlide  = goToHeroSlide;

  // 7) Llamada inicial
  updateHero();
});
