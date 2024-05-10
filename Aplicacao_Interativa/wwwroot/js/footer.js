var meuHTML = `
<footer class="footer has-bg-image" style="background-image: url('/img/footer-bg.png')">
    <div class="container">

      <div class="footer-top">

        <div class="footer-brand">



        </div>

        <div class="footer-link-box">

          <ul class="footer-list">

            <li>
              <p class="footer-list-title">Nossos Links</p>
            </li>

            <li>
              <a href="#" class="footer-link has-before">Serviços</a>
            </li>

            <li>
              <a href="#" class="footer-link has-before">Preços</a>
            </li>

            <li>
              <a href="#" class="footer-link has-before">Galeria</a>
            </li>

            <li>
              <a href="#" class="footer-link has-before">Agendamento</a>
            </li>

            <li>
              <a href="#" class="footer-link has-before">Contato</a>
            </li>

          </ul>

          <ul class="footer-list">

            <li>
              <p class="footer-list-title">Serviços</p>
            </li>

            <li>
              <a href="#" class="footer-link has-before">Corte</a>
            </li>

            <li>
              <a href="#" class="footer-link has-before">Barba e Sombrançelhas</a>
            </li>

            <li>
              <a href="#" class="footer-link has-before">Pintura</a>
            </li>

            <li>
              <a href="#" class="footer-link has-before">Acabamento</a>
            </li>

            <li>
              <a href="#" class="footer-link has-before">Barboterapia</a>
            </li>

          </ul>


          <ul class="footer-list">

            <li>
              <p class="footer-list-title">Novidades</p>
            </li>

            <li>
              <div class="blog-card">

                <figure class="card-banner img-holder" style="--width: 70; --height: 75;">
                  <img src="~/img/site/footer-blog-1.jpg" width="70" height="75" loading="lazy"
                    alt="The beginners guide to Henna Brows in Brisbane" class="img-cover">
                </figure>

                <div class="card-content">
                  <h3>
                    <a href="#" class="card-title">The beginners guide to Henna Brows in Brisbane</a>
                  </h3>

                  <div class="card-date">
                    <ion-icon name="calendar-outline" aria-hidden="true"></ion-icon>

                    <time datetime="2022-08-25">25 August 2022</time>
                  </div>
                </div>

              </div>
            </li>


            <li>
              <div class="blog-card">

                <figure class="card-banner img-holder" style="--width: 70; --height: 75;">
                  <img src="~/img/site/footer-blog-2.jpg" width="70" height="75" loading="lazy"
                    alt="How do I get rid of unwanted hair on my face?" class="img-cover">
                </figure>

                <div class="card-content">
                  <h3>
                    <a href="#" class="card-title">How do I get rid of unwanted hair on my face?</a>
                  </h3>

                  <div class="card-date">
                    <ion-icon name="calendar-outline" aria-hidden="true"></ion-icon>

                    <time datetime="2022-08-25">25 August 2022</time>
                  </div>
                </div>

              </div>
            </li>


          </ul>

          <ul class="footer-list">

            <li>
              <p class="footer-list-title">Fale Conosco</p>
            </li>

            <li class="footer-list-item">
              <ion-icon name="location-outline" aria-hidden="true"></ion-icon>

              <address class="contact-link">
                local
              </address>
            </li>

            <li class="footer-list-item">
              <ion-icon name="call-outline" aria-hidden="true"></ion-icon>

              <a href="tel:+0123456789" class="contact-link">(31)1234-5678</a>
            </li>

            <li class="footer-list-item">
              <ion-icon name="time-outline" aria-hidden="true"></ion-icon>

              <span class="contact-link">Segunda - Sábado 08:00 - 21:00</span>
            </li>

            <li class="footer-list-item">
              <ion-icon name="mail-outline" aria-hidden="true"></ion-icon>

              <a href="mailto:support@gmail.com" class="contact-link">support@gmail.com</a>
            </li>

          </ul>

        </div>

      </div>

      <div class="footer-bottom">
        <p class="copyright">
          &copy; 2024 <a href="#" class="copyright-link">TI-Barberapp</a>. Todos os direitos reservados.
        </p>
      </div>

    </div>
  </footer>`;

console.log(meuHTML);



var meuCSS = `
    
:root {

  /**
   * colors
   */

  --rich-black-fogra-39_50: hsla(0, 0%, 5%, 0.5);
  --rich-black-fogra-39: hsl(0, 0%, 5%);
  --indian-yellow_10: hsla(36, 61%, 58%, 0.1);
  --indian-yellow: hsl(36, 61%, 58%);
  --harvest-gold: hsl(36, 66%, 53%);
  --eerie-black-1: hsl(0, 0%, 14%);
  --eerie-black-2: hsl(0, 0%, 12%);
  --eerie-black-2_85: hsla(0, 0%, 12%, 0.85);
  --eerie-black-3: hsl(0, 0%, 8%);
  --sonic-silver: hsl(0, 0%, 44%);
  --davys-gray: hsl(210, 9%, 31%);
  --light-gray: hsl(0, 0%, 80%);
  --platinum: hsl(0, 0%, 91%);
  --black_30: hsla(0, 0%, 0%, 0.3);
  --white_10: hsla(0, 0%, 100%, 0.1);
  --white_30: hsla(0, 0%, 100%, 0.3);
  --white_50: hsla(0, 0%, 100%, 0.5);
  --white: hsl(0, 0%, 100%);
  --jet: hsl(0, 0%, 21%);

  /**
   * typography
   */

  --ff-oswald: 'Oswald', sans-serif;
  --ff-rubik: 'Rubik', sans-serif;

  --fs-40: 4rem;
  --fs-30: 3rem;
  --fs-24: 2.4rem;
  --fs-18: 1.8rem;
  --fs-14: 1.4rem;
  --fs-13: 1.3rem;

  --fw-300: 300;
  --fw-500: 500;
  --fw-600: 600;
  --fw-700: 700;

  /**
   * spacing
   */

  --section-padding: 80px;

  /**
   * shadow
   */

  --shadow-1: 10px 0 60px hsla(0, 0%, 15%, 0.07);
  --shadow-2: 10px 0 60px hsla(0, 0%, 15%, 0.1);

  /**
   * radius
   */

  --radius-5: 5px;
  --radius-8: 8px;

  /**
   * transition
   */

  --transition-1: 0.25s ease;
  --transition-2: 0.5s ease;
  --cubic-out: cubic-bezier(0.33, 0.85, 0.4, 0.96);

}

/*-----------------------------------*\
  #RESET
\*-----------------------------------*/

*,
*::before,
*::after {
  margin: 0;
  padding: 0;
  box-sizing: border-box;
}

li {
  list-style: none;
}

a,
img,
span,
data,
input,
select,
button,
textarea,
ion-icon {
  display: block;
}

a {
  color: inherit;
  text-decoration: none;
}

img {
  height: auto;
}

input,
select,
button,
textarea {
  background: none;
  border: none;
  font: inherit;
}

input,
select,
textarea {
  width: 100%;
}

button {
  cursor: pointer;
}

ion-icon {
  pointer-events: none;
}

address {
  font-style: normal;
}

html {
  font-family: var(--ff-rubik);
  font-size: 10px;
  scroll-behavior: smooth;
}

body {
  background-color: var(--white);
  color: var(--sonic-silver);
  font-size: 1.6rem;
  line-height: 2;
}

:focus-visible {
  outline-offset: 4px;
}

::-webkit-scrollbar {
  width: 10px;
}

::-webkit-scrollbar-track {
  background-color: hsl(0, 0%, 98%);
}

::-webkit-scrollbar-thumb {
  background-color: hsl(0, 0%, 80%);
}

::-webkit-scrollbar-thumb:hover {
  background-color: hsl(0, 0%, 70%);
}


/*-----------------------------------*\
  #REUSED STYLE
\*-----------------------------------*/

.container {
  padding-inline: 15px;
}

.section {
  padding-block: var(--section-padding);
}

.has-before,
.has-after {
  position: relative;
  z-index: 1;
}

.has-before::before,
.has-after::after {
  position: absolute;
  content: "";
}

.has-bg-image {
  background-repeat: no-repeat;
  background-size: cover;
  background-position: center;
}

.h1,
.h2,
.h3 {
  font-family: var(--ff-oswald);
  line-height: 1.3;
}

.h1,
.h2 {
  text-transform: uppercase;
}

.h1,
.h3 {
  font-weight: var(--fw-600);
}

.h1 {
  color: var(--white);
  font-size: var(--fs-40);
}

.h2,
.h3 {
  color: var(--eerie-black-1);
}

.h2 {
  font-size: var(--fs-30);
}

.h3 {
  font-size: var(--fs-24);
}

.btn {
  color: var(--white);
  background-color: var(--indian-yellow);
  display: flex;
  align-items: center;
  gap: 10px;
  max-width: max-content;
  padding: 10px 25px;
  font-family: var(--ff-oswald);
  font-size: var(--fs-14);
  font-weight: var(--fw-600);
  text-transform: uppercase;
  border-radius: var(--radius-5);
  overflow: hidden;
}

.btn::before {
  background-color: var(--eerie-black-1);
  inset: 0;
  z-index: -1;
  transform: skewY(-15deg) scaleY(0);
  transition: var(--transition-2);
}

.btn:is(:hover, :focus)::before {
  transform: skewY(-15deg) scaleY(2.5);
}

.text-center {
  text-align: center;
}

.grid-list {
  display: grid;
  gap: 30px;
}

.img-holder {
  aspect-ratio: var(--width) / var(--height);
  background-color: var(--light-gray);
  overflow: hidden;
}

.img-cover {
  width: 100%;
  height: 100%;
  object-fit: cover;
}


.footer {
    background-color: var(--eerie-black-2);
    padding-block-end: 30px;
  }
  
  .footer-top {
    margin-block-end: 65px;
  }
  
  .footer-brand {
    border: 1px solid var(--white_10);
    margin-block-end: 70px;
  }
  
  .footer .logo {
    text-align: center;
    padding: 25px;
    border-block-end: 1px solid var(--white_10);
  }
  
  .footer .input-wrapper {
    background-color: var(--white);
    position: relative;
    margin: 25px;
    padding: 15px;
  }
  
  .footer .input-wrapper:focus-within {
    outline: 3px solid var(--white_30);
  }
  
  .footer .email-field {
    text-align: center;
    margin-block-end: 15px;
    color: inherit;
    outline: none;
  }
  
  .footer .btn {
    max-width: 100%;
    width: 100%;
    justify-content: center;
  }
  
  .footer-link-box {
    display: grid;
    gap: 50px;
  }
  
  .footer-list-title {
    color: var(--white);
    font-family: var(--ff-oswald);
    font-size: var(--fs-18);
    font-weight: var(--fw-600);
    text-transform: uppercase;
    margin-block-end: 30px;
  }
  
  .footer-link::before {
    position: static;
    padding: 2.5px;
    background-color: var(--white_30);
    display: block;
    border-radius: 50%;
    transition: var(--transition-1);
  }
  
  .footer-link,
  .blog-card,
  .blog-card .card-date,
  .footer-list-item {
    display: flex;
    align-items: center;
  }
  
  .footer-link {
    color: var(--white_50);
    gap: 10px;
    margin-block-start: 8px;
    transition: var(--transition-1);
  }

  .footer-link {
    color: var(--white_50);
    gap: 10px;
    margin-block-start: 8px;
    transition: var(--transition-1);
  }
  
  .footer-link:is(:hover, :focus)::before {
    background-color: var(--white);
  }
  
  .blog-card {
    gap: 25px;
    margin-block-start: 20px;
  }
  
  .blog-card .card-banner {
    flex-shrink: 0;
  }
  
  .blog-card .card-title {
    color: var(--white);
    font-family: var(--ff-oswald);
    font-size: var(--fs-14);
    font-weight: var(--fw-500);
    line-height: 1.5;
    margin-block-end: 5px;
    transition: var(--transition-1);
  }
  
  .blog-card .card-title:is(:hover, :focus) {
    color: var(--indian-yellow);
  }
  
  .blog-card .card-date {
    gap: 5px;
    font-size: var(--fs-13);
    text-transform: uppercase;
    color: var(--white_50);
  }
  
  .blog-card .card-date ion-icon {
    --ionicon-stroke-width: 50px;
  }
  
  .footer-list-item {
    align-items: flex-start;
    gap: 10px;
    margin-block-start: 10px;
  }
  
  .footer-list-item ion-icon {
    color: var(--indian-yellow);
    font-size: 18px;
    flex-shrink: 0;
    --ionicon-stroke-width: 50px;
    margin-block: 7px;
  }
  
  .contact-link {
    color: var(--white_50);
    transition: var(--transition-1);
  }
  
  a.contact-link:is(:hover, :focus) {
    color: var(--white);
  }
  
  .footer-bottom {
    background-color: var(--eerie-black-3);
    text-align: center;
    padding: 15px;
  }
  
  .copyright-link {
    display: inline-block;
    color: var(--indian-yellow);
  }
  



  @media (min-width: 575px) {

    /**
     * CUSTOM PROPERTY
     */
  
    :root {
  
      /**
       * typography
       */
  
      --fs-40: 6rem;
  
    }
  
  
  
    /**
     * REUSED STYLE
     */
  
    .container,
    .header-top {
      max-width: 540px;
      width: 100%;
      margin-inline: auto;
    }
  
    .btn {
      padding: 13px 40px;
    }
  
    .h2 {
      --fs-30: 3.5rem;
    }
  
  
  
    /**
     * HEADER
     */
  
    .header-top {
      position: absolute;
      top: 0;
      left: 50%;
      transform: translateX(-50%);
      max-width: 600px;
      z-index: 4;
      background-color: var(--white);
      border-radius: 0 0 20px 20px;
    }
  
    .header-top-item:first-child {
      display: flex;
      align-items: center;
      gap: 10px;
    }
  
    .header-top-item ion-icon {
      font-size: 18px;
      color: var(--indian-yellow);
      --ionicon-stroke-width: 50px;
    }
  
    .header-top-item .item-title {
      color: var(--eerie-black-1);
      font-weight: var(--fw-500);
    }
  
    .header-top-item .item-link {
      transition: var(--transition-1);
    }
  
    .header-top-item .item-link:is(:hover, :focus) {
      color: var(--indian-yellow);
    }
  
    .header-top-list {
      justify-content: space-between;
    }
  
    .logo {
      font-size: 3rem;
    }
  
    .logo .span {
      font-size: 1.4rem;
    }
  
  
  
    /**
     * HERO
     */
  
    .hero {
      padding-block-start: calc(var(--section-padding) + 80px);
    }
  
    .hero-text {
      font-size: var(--fs-18);
    }
  
  
  
  
    /**
     * FOOTER
     */
  
  
  
    .footer-link-box {
      grid-template-columns: 1fr 1fr;
  
    }
  
    .footer-list:is(:nth-child(3), :nth-child(4)) {
      grid-column: 1 / 3;
    }
  
    .blog-card .card-title {
      --fs-14: 1.7rem;
      max-width: 25ch;
    }
  
    .footer-brand {
      align-items: center;
    }
  
  }
  
  
  
  
  
  /**
   * responsive for large than 768px screen
   */
  
  @media (min-width: 768px) {
  
    /**
     * CUSTOM PROPERTY
     */
  
    :root {
  
      /**
       * typography
       */
  
      --fs-40: 8rem;
  
    }
  
  
  
    /**
     * REUSED STYLE
     */
  
    .container {
      max-width: 720px;
    }
  
    .h2 {
      --fs-30: 4rem;
    }
  
    .section-text {
      max-width: 50ch;
      margin-inline: auto;
    }
  
  
  
    /**
     * HEADER
     */
  
    .header-top {
      max-width: 780px;
    }
  
  
  
  
  
    /**
     * FOOTER
     */
  
    .footer-list:is(:nth-child(3), :nth-child(4)) {
      grid-column: auto;
    }
  
  }
  
  
  
  
  
  /**
   * responsive for large than 992px screen
   */
  
  @media (min-width: 992px) {
  
    /**
     * CUSTOM PROPERTY
     */
  
    :root {
  
      /**
       * typography
       */
  
      --fs-40: 10rem;
  
    }
  
  
  
    /**
     * REUSED STYLE
     */
  
    .container {
      max-width: 960px;
    }
  
  
  
    /**
     * HEADER
     */
  
    .nav-toggle-btn {
      display: none;
    }
  
    .header-top {
      max-width: 1020px;
    }
  
    .header-bottom {
      padding-block: 20px;
    }
  
    .navbar,
    .navbar-list,
    .navbar-item {
      all: unset;
    }
  
    .navbar-list,
    .header .btn {
      display: flex;
    }
  
    .navbar-link {
      padding-inline: 10px;
    }
  
  
  
    /**
     * HERO
     */
  
    .hero {
      --section-padding: 150px;
      padding-block-start: calc(var(--section-padding) + 100px);
    }
  
    .hero-title,
    .hero-text {
      max-width: 600px;
    }
  
  
  
  
  
  
  
    /**
     * FOOTER
     */
  
    .footer-brand {
      display: flex;
      align-items: center;
    }
  
    .footer .logo {
      padding: 60px 70px;
      border-block-end: none;
      border-inline-end: 1px solid var(--white_10);
    }
  
    .footer .input-wrapper {
      flex-grow: 1;
      margin-inline: 70px;
    }
  
  }
  
  
  
  
  
  /**
   * responsive for large than 1200px screen
   */
  
  @media (min-width: 1200px) {
  
    /**
     * CUSTOM PROPERTY
     */
  
    :root {
  
      /**
       * typography
       */
  
      --fs-40: 11rem;
  
      /**
       * spacing
       */
  
      --section-padding: 120px;
  
    }
  
  
  
    /**
     * REUSED STYLE
     */
  
    .container {
      max-width: 1200px;
    }
  
  
  
    /**
     * HEADER
     */
  
    .header-top {
      max-width: 1260px;
    }
  
    .header-top-list {
      gap: 30px;
    }
  
    .header-top-item {
      display: flex;
      align-items: center;
      gap: 10px;
    }
  
    .header-top-item:nth-child(2) {
      margin-inline-end: auto;
    }
  
  
  
    /**
     * HERO
     */
  
    .hero {
      background-position: left;
      padding-block-end: 200px;
    }
  
    .hero-title,
    .hero-text {
      max-width: 680px;
    }
  
  
  
  
    /**
     * FOOTER
     */
  
    .footer-link-box {
      grid-template-columns: 0.5fr 0.5fr 1fr 0.8fr;
    }
  
  }
  .login-register-container {
    display: flex;
    justify-content: space-between;
  }
  
  /* Estilos adicionais conforme necessário para os formulários de login e registro */
  .login,
  .register {
    width: 48%; /* ou ajuste conforme necessário */
  }
  
  /* Estilos adicionais para ajustar o layout para dispositivos menores */
  @media screen and (max-width: 768px) {
    .login-register-container {
        flex-direction: column;
    }
  
    .login,
    .register {
        width: 100%;
    }
  }
  

`;


console.log(meuCSS);

var style = document.createElement("style");
style.innerHTML = meuCSS;
document.head.appendChild(style);

// Criando um elemento div e definindo seu HTML
var div = document.createElement("div");
div.innerHTML = meuHTML;

// Adicionando o elemento div ao corpo do documento
document.body.appendChild(div);