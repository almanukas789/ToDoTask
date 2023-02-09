<template>
    <nav class="navbar"  role="navigation" aria-label="main navigation">
        <div class="navbar-brand">
          <a role="button" class="navbar-burger" aria-label="menu" aria-expanded="false" data-target="navbar">
            <span aria-hidden="true"></span>
            <span aria-hidden="true"></span>
            <span aria-hidden="true"></span>
          </a>
        </div>
        <div id="navbar" class="navbar-menu">
          <div class="navbar-start">
            <a class="navbar-item" href="/">
              <img src="../assets/homeicon.png"/>
            </a>
            <a class="navbar-item">
                <router-link style="color:#BEB7A4" :to="{ name: 'About' }">
                    About
                </router-link>
        </a>
          </div>
          <div class="navbar-end">
            <a class="navbar-item" href="https://github.com/almanukas789/ToDoTask" target="_blank">
                <img src="../assets/githubicon.png"/>
        </a>
        <a class="navbar-item" href="https://lt.linkedin.com/in/almanas-alaburda-6675261b8" target="_blank">
            <img src="../assets/linkedinicon.png"/>
    </a>
          </div>
        </div>
      </nav>
</template>
<script>
export default {
  data () {
    return {
    }
  }
}
</script>
<style>
.navbar-item, .navbar-link{
    color:black;
}
.navbar,.navbar-dropdown{
    padding: 12px;
    margin-top: 10px;
    margin-left: 10px;
    margin-right: 10px;
    margin-bottom: 30px;
    border-radius: 25px;
  background-color: black;
}
</style>
