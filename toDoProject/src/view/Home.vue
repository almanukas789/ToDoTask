<template>
    <div id="top">
        <NavBar/>
            <div class="columns">
              <div class="column is-narrow">
               <SideBar/>
              </div>
              <div class="column">
                <MainBox
                :wdata="wdata"
                />
              </div>
            </div>
        <button @click="hello">Hello</button>
        <!-- <div class="envcard" v-for="item in wdata" :key="item.id">
          <div class="card">
            <header class="card-header">
              <p class="card-header-title">
                Date: {{item.date}}
              </p>
              <button class="card-header-icon" aria-label="more options">
                <span class="icon">
                  <i class="fas fa-angle-down" aria-hidden="true"></i>
                </span>
              </button>
            </header>
            <div class="card-content">
              <div class="content">
                Temperature: {{ item.temperatureC }}C
                <br/>
                Summary: {{ item.summary }}
              </div>
            </div>
          </div>
          <br/>
        </div> -->
    </div>
</template>

<script>
import NavBar from '../components/NavBar.vue'
import SideBar from '../components/SideBar.vue'
import MainBox from '../components/MainBox.vue'
import axios from 'axios'
export default {
  components: {
    NavBar,
    SideBar,
    MainBox
  },
  data () {
    return {
      wdata: []
    }
  },
  methods: {
    hello () {
      console.log(this.wdata)
      const tempData = {
        date: 'this.title',
        temperatureC: 'this.author',
        summary: 'this.body'
      }
      axios
        .post('https://localhost:7281/WeatherForecast', tempData)
        .then((response) => (tempData.id = response.data.id))
        .catch((error) => {
          this.errorMessage = error.message
          console.error('ERRORAS!', error)
        })
    }
  },
  mounted () {
    axios
      .get('https://localhost:7281/WeatherForecast')
      .then((r) => (this.wdata = r.data))
      .catch((error) => {
        console.log(error)
        this.errored = true
      })
  }
}
</script>
<style>
.main-container{
  background-color: red;
}
.envcard{
  margin-left: 20px;
  margin-right: 20px;
}
</style>
