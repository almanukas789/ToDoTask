<template>
<div>
  <UpdateModal
  :updateData="updateData"
  :updateModalVisability="updateModalVisability"
  />
    <div v-if="wdata==''" class="box"><p style="text-align:center">No data found!</p></div>
    <div v-else>
      <div class="container">
        <br/>
          <div v-for="item in wdata" :key="item.id" class="box">
            <p><strong>Day: </strong>{{item.date}}</p>
            <p>{{item.task}}</p>
            <p>{{ item.status }}</p>
            <button class="button is-danger" @click="deleteTask(item.ID)">Delete</button>
            <button class="button" @click="updateTask(item)">Update</button>
          </div>
          <br/>
    </div>
    </div>
</div>
</template>
<script>
import UpdateModal from './UpdateModal.vue'
import axios from 'axios'
export default {
  components: {
    UpdateModal
  },
  props: ['wdata'],
  data () {
    return {
      updateData: [],
      updateModalVisability: false
    }
  },
  methods: {
    updateTask (item) {
      this.updateData = item
      this.toggleUpdateModal()
    },
    toggleUpdateModal () {
      this.updateModalVisability = !this.updateModalVisability
    },
    async deleteTask (item) {
      await axios
        .delete(this.$apiUrl + '?id=' + item)
        .then((response) => {
          console.log('Deleted')
        })
        .catch(function (error) {
          console.log(error.response)
        })
      await this.$emit('updateData')
    }
  }
}
</script>
<style>
.box{
  margin-left: 5px;
  margin-right: 5px;
  margin-top: 5px;
  border-radius: 20px;
  background-color: #BEB7A4 !important;
}
.container{
  background-color: black;
  border-radius: 25px;
  margin-right: 10px;
}
</style>
