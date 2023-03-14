<template>
<div>
  <UpdateModal
  :updateData="updateData"
  :updateModalVisability="updateModalVisability"
  @toggleUpdateModal="toggleUpdateModal"
  />
  <div v-if="wdata==''" class="box"><p style="text-align:center">No tasks!</p></div>
  <div v-else>
    <div class="container">
      <br/>
      <h1 style="text-align:center; color:#BEB7A4">{{ tableTitle }}</h1>
      <div v-for="item in wdata" :key="item.id" class="box">
        <div style="display:flex">
          <div v-if="item.status === '0'" @click="changeStatus(item,'1')" class="checkbox">
            <img src="../assets/uncheck.png" width="50" height="50"/>
          </div>
          <div v-if="item.status === '1'" @click="changeStatus(item,'0')" class="checkbox">
            <img src="../assets/check.png" width="50" height="50"/>
          </div>
          <div style="display:flex ; flex-direction: column;">
            <h1 style="display:block;font-size: 20px;"><strong>Task: </strong>{{item.task}}</h1>
            <h1 style="display:block"><strong>Dedicated time for the task:</strong> {{item.time}} minutes</h1>
          </div>
          <div style="margin-left:auto">
            <button class="button" style="width: 55px; height: 45px;" @click="updateTask(item)"><img src="../assets/edit.png" width="100" height="100"/></button>
            <button class="button is-danger" style="width: 55px; height: 45px;" @click="toggleConfirmation(item.ID)"><img src="../assets/delete.png" width="100" height="100"/></button>
          </div>
        </div>
      </div>
      <br/>
    </div>
  </div>
</div>
</template>
<script>
import axios from 'axios'
import UpdateModal from './UpdateModal.vue'
export default {
  components: {
    UpdateModal
  },
  props: {
    wdata: {
      default: undefined
    },
    tableTitle: {
      type: String
    }
  },
  data () {
    return {
      updateData: [],
      updateModalVisability: false
    }
  },
  methods: {
    async changeStatus (item, status) {
      await axios
        .put(this.$apiUrl + '?id=' + item.ID + '&task=' + item.task + '&time=' + item.time + '&status=' + status)
        .catch((error) => {
          console.log(error)
        })
      await this.$emit('updateData')
    },
    toggleConfirmation (id) {
      this.$emit('toggleConfirmation', id)
    },
    updateTask (item) {
      this.updateData = item
      this.toggleUpdateModal()
    },
    toggleUpdateModal () {
      this.updateModalVisability = !this.updateModalVisability
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
h1 {
  white-space: pre-wrap;
  word-break: break-word;
}
.checkbox{
  display: flex;
  align-items: center;
  width: 60px;
  height:50px;
}
</style>
