var meuHTML = `  <header class="header">

<div class="header-top">
  <div class="container">

    <ul class="header-top-list mb-0">

      <li class="header-top-item">
        <ion-icon name="call-outline" aria-hidden="true"></ion-icon>

        <p class="item-title mb-0">Contato :</p>

        <a href="tel:01234567895" class="item-link">(31) 1234-5678</a>
      </li>

      <li class="header-top-item">
        <ion-icon name="time-outline" aria-hidden="true"></ion-icon>

        <p class="item-title mb-0">Funcionamento :</p>

        <p class="item-text mb-0">Segunda - Sábado 08:00 - 19:00</p>
      </li>

      <li>
        <ul class="social-list">

          <li>
            <a href="" class="social-link">
              <ion-icon name="logo-facebook"></ion-icon>
            </a>
          </li>

          <li>
            <a href="#" class="social-link">
              <ion-icon name="logo-twitter"></ion-icon>
            </a>
          </li>

          <li>
            <a href="#" class="social-link">
              <ion-icon name="logo-youtube"></ion-icon>
            </a>
          </li>

          <li>
            <a href="#" class="social-link">
              <ion-icon name="chatbubble-ellipses-outline"></ion-icon>
            </a>
          </li>

        </ul>
      </li>

    </ul>

  </div>
</div>

<div class="header-bottom" data-header>
  <div class="container">

    <a href="/Cliente/Index" class="logo">
      Barber reach
      <span class="span">BARBEARIA</span>
    </a>

    <nav class="navbar container" data-navbar>
      <ul class="navbar-list">

        <li class="navbar-item">
          <a href="/Cliente/Index" class="navbar-link" data-nav-link>Home</a>
        </li>

        <li class="navbar-item">
          <a href="#services" class="navbar-link" data-nav-link>Serviços</a>
        </li>

        <li class="navbar-item">
          <a href="#pricing" class="navbar-link" data-nav-link>Planos & kits</a>
        </li>

        <li class="navbar-item">
          <a href="#gallery" class="navbar-link" data-nav-link>Galeria</a>
        </li>
        <li class="navbar-item">
          <a href="perfil.html" class="navbar-link" data-nav-link>Meu Perfil</a>
        </li>


      </ul>
    </nav>

    <button class="nav-toggle-btn" aria-label="toggle menu" data-nav-toggler>
      <ion-icon name="menu-outline" aria-hidden="true"></ion-icon>
    </button>

    <a href="/Login/Sair" class="btn has-before">
      <span class="span">SAIR</span>

      <ion-icon name="arrow-forward" aria-hidden="true"></ion-icon>
    </a>

  </div>
</div>

</header>

`;

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
  --white_30: hsla(0, 0%, 100%, 0.3 );
  --white_50: hsla(0, 0%, 100%, 0.5);
  --white: hsl(0, 0%, 100%);
  --jet: hsl(0, 0%, 21%);

  /**
   * typography
   */

  --ff-oswald : 'Oswald', sans-serif;
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

li { list-style: none; }

a,
img,
span,
data,
input,
select,
button,
textarea,
ion-icon { display: block; }

a {
  color: inherit;
  text-decoration: none;
}

img { height: auto; }

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
textarea { width: 100%; }

button { cursor: pointer; }

ion-icon { pointer-events: none; }

address { font-style: normal; }

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

:focus-visible { outline-offset: 4px; }

::-webkit-scrollbar { width: 10px; }

::-webkit-scrollbar-track { background-color: hsl(0, 0%, 98%); }

::-webkit-scrollbar-thumb { background-color: hsl(0, 0%, 80%); }

::-webkit-scrollbar-thumb:hover { background-color: hsl(0, 0%, 70%); }


/*-----------------------------------*\
  #REUSED STYLE
\*-----------------------------------*/

.container { padding-inline: 15px; }

.section { padding-block: var(--section-padding); }

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
.h2 { text-transform: uppercase; }

.h1,
.h3 { font-weight: var(--fw-600); }

.h1 {
  color: var(--white);
  font-size: var(--fs-40);
}

.h2,
.h3 { color: var(--eerie-black-1); }

.h2 { font-size: var(--fs-30); }

.h3 { font-size: var(--fs-24); }

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

.btn:is(:hover, :focus)::before { transform: skewY(-15deg) scaleY(2.5); }

.text-center { text-align: center; }

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


/*-----------------------------------*\
  #HEADER
\*-----------------------------------*/

.header-top-item,
.header .btn { display: none; }

.header-top-list,
.header-top-list .social-list {
  display: flex;
  align-items: center;
}

.header-top-list { justify-content: center; }

.header-top-list .social-list {
  gap: 20px;
  padding-block: 15px;
}

.header-top-list .social-link {
  color: var(--sonic-silver);
  font-size: 15px;
  transition: var(--transition-1);
}

.header-top-list .social-link:is(:hover, :focus) { color: var(--indian-yellow); }

.header-bottom {
  position: absolute;
  top: 45px;
  left: 0;
  width: 100%;
  padding-block: 10px;
  z-index: 4;
}

.header-bottom.active {
  position: fixed;
  top: 0;
  background-color: var(--rich-black-fogra-39);
  transform: translateY(-100%);
  animation: slideIn 0.5s ease forwards;
}

@keyframes slideIn {
  0% { transform: translateY(-100%); }
  100% { transform: translateY(0); }
}

.header-bottom > .container {
  display: flex;
  justify-content: space-between;
  align-items: center;
}

.logo {
  color: var(--indian-yellow);
  font-family: var(--ff-oswald);
  font-size: 2.7rem;
  font-weight: var(--fw-600);
  text-transform: uppercase;
  line-height: 1.4;
}

.logo .span {
  color: var(--white);
  font-family: var(--ff-rubik);
  font-size: 1.3rem;
  font-weight: var(--fw-300);
  text-transform: capitalize;
  letter-spacing: 2px;
}

.nav-toggle-btn {
  color: var(--white);
  font-size: 40px;
}

.navbar {
  position: absolute;
  padding-inline: 0;
  top: 100%;
  left: 15px;
  right: 15px;
  background-color: var(--rich-black-fogra-39);
  max-height: 0;
  overflow: hidden;
  transition: 0.15s var(--cubic-out);
}

.navbar.active {
  max-height: 321px;
  transition-duration: 0.5s;
}

.navbar-list {
  border-block-start: 1px solid var(--jet);
  margin-block: 25px;
}

.navbar-item { border-block-end: 1px solid var(--jet); }

.navbar-link {
  color: var(--white);
  font-family: var(--ff-oswald);
  font-weight: var(--fw-600);
  text-transform: uppercase;
  line-height: 1.5;
  padding: 10px 30px;
  transition: var(--transition-1);
}

.navbar-link:is(:hover, :focus) { color: var(--indian-yellow); }


/*-----------------------------------*\
  #HERO
\*-----------------------------------*/


/*-----------------------------------*\
  #MEDIA QUERIES
\*-----------------------------------*/



@media (min-width: 575px) {

 

  :root {


    --fs-40: 6rem;

  }




  .container,
  .header-top {
    max-width: 540px;
    width: 100%;
    margin-inline: auto;
  }

  .btn { padding: 13px 40px; }

  .h2 { --fs-30: 3.5rem; }



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

  .header-top-item .item-link { transition: var(--transition-1); }

  .header-top-item .item-link:is(:hover, :focus) { color: var(--indian-yellow); }

  .header-top-list { justify-content: space-between; }

  .logo { font-size: 3rem; }

  .logo .span { font-size: 1.4rem; }
}

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

  .container { max-width: 720px; }

  .h2 { --fs-30: 4rem; }

  .section-text {
    max-width: 50ch;
    margin-inline: auto;
  }



  /**
   * HEADER
   */

  .header-top { max-width: 780px; }






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

  .container { max-width: 960px; }



  /**
   * HEADER
   */

  .nav-toggle-btn { display: none; }

  .header-top { max-width: 1020px; }

  .header-bottom { padding-block: 20px; }

  .navbar,
  .navbar-list,
  .navbar-item { all: unset; }

  .navbar-list,
  .header .btn { display: flex; }

  .navbar-link { padding-inline: 10px; }

  

  /**
   * HERO
   */

  .hero {
    --section-padding: 150px;
    padding-block-start: calc(var(--section-padding) + 100px);
  }

  .hero-title,
  .hero-text { max-width: 600px; }




 

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

  .container { max-width: 1200px; }



  /**
   * HEADER
   */

  .header-top { max-width: 1260px; }

  .header-top-list { gap: 30px; }

  .header-top-item {
    display: flex;
    align-items: center;
    gap: 10px;
  }

  .header-top-item:nth-child(2) { margin-inline-end: auto; }



  /**
   * HERO
   */

  .hero {
    background-position: left;
    padding-block-end: 200px;
  }

  .hero-title,
  .hero-text { max-width: 680px; }
}


`;


console.log(meuCSS);


// Definindo o JavaScript
var meuJavaScript = `

const addEventOnElem = function (elem, type, callback) {
  if (elem.length > 1) {
    for (let i = 0; i < elem.length; i++) {
      elem[i].addEventListener(type, callback);
    }
  } else {
    elem.addEventListener(type, callback);
  }
}



const navbar = document.querySelector("[data-navbar]");
const navToggler = document.querySelector("[data-nav-toggler]");
const navLinks = document.querySelectorAll("[data-nav-link]");

const toggleNavbar = () => navbar.classList.toggle("active");

addEventOnElem(navToggler, "click", toggleNavbar);

const closeNavbar = () => navbar.classList.remove("active");

addEventOnElem(navLinks, "click", closeNavbar);


const header = document.querySelector("[data-header]");
const backTopBtn = document.querySelector("[data-back-top-btn]");

const headerActive = function () {
  if (window.scrollY > 100) {
    header.classList.add("active");
    backTopBtn.classList.add("active");
  } else {
    header.classList.remove("active");
    backTopBtn.classList.remove("active");
  }
}

addEventOnElem(window, "scroll", headerActive);




`;
console.log(meuJavaScript);


// Adicionando o HTML ao DOM
document.body.innerHTML = meuHTML;

// Criando uma tag de script para adicionar o JavaScript
var scriptTag = document.createElement("script");
scriptTag.innerHTML = meuJavaScript;
document.body.appendChild(scriptTag);

// Adicionando o CSS ao DOM


var styleTag = document.createElement("style");
styleTag.innerHTML = meuCSS;
document.head.appendChild(styleTag);