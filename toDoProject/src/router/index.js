import Vue from 'vue'
import Router from 'vue-router'
import Home from '../view/Home'
import About from '../view/About'
import NotFound from '../view/NotFound.vue'
Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'Home',
      component: Home
    },
    {
      path: '/about',
      name: 'About',
      component: About
    },
    {
      path: '/*',
      name: '404',
      component: NotFound
    }
  ]
})
