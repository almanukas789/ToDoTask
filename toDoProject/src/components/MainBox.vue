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
      <br/>
      <div v-for="item in wdata" :key="item.id" class="box">
        <div style="display:flex">
          <div style="display:flex ; flex-direction: column;">
            <h1 style="display:block;font-size: 20px;"><strong>Task: </strong>{{item.task}}</h1>
            <h1 style="display:block"><strong>Dedicated time for the task:</strong> {{item.time}} minutes</h1>
          </div>
          <div style="margin-left:auto">
            <button class="button" @click="updateTask(item)"><img src="../assets/edit.png" width="20" height="20"/></button>
            <button class="button is-danger" @click="toggleConfirmation(item.ID)"><img src="../assets/delete.png" width="20" height="20"/></button>
          </div>
        </div>
      </div>
      <br/>
    </div>
  </div>
</div>
</template>
<script>
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
</style>
