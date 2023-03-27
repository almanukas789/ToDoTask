// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'
import App from './App'
import router from './router'
import CrudPlugin from './plugins/crud'

Vue.config.productionTip = false

Vue.prototype.$apiUrl = 'https://localhost:7281/api/ToDoTask'
Vue.use(CrudPlugin)

/* eslint-disable no-new */
new Vue({
  el: '#app',
  router,
  components: { App },
  template: '<App/>'
})
