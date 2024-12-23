<template>
  <div class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
    <StudentCard
      v-for="student in students"
      :key="student.id"
      :student="student"
    />
  </div>
</template>

<script setup>
import StudentCard from "./StudentCard.vue";

defineProps({
  students: {
    type: Array,
    required: true,
  },
});
</script>
