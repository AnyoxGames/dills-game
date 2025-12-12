13
3405909065729
404868344150154 1761863290393717900
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": -15.5151968002319336,
    "Y": 9.1936845779418945
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "404866269705368:1761863289910369600",
  "next_sibling": "404871277261252:1761863291077135800",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "404868344387299:1761863290393772100",
  "component_type": "Internal_Component",
  "internal_component_type": "Interactable",
  "data": {
    "text": "Harvest Pine Tree",
    "radius": 1,
    "required_hold_time": 0.3000000119209290
  }
},
{
  "cid": 4,
  "aoid": "404868344516643:1761863290393802200",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "404868344387299:1761863290393772100",
    "DefaultRenderer": "404868344563943:1761863290393813300",
    "DepletedRenderer": "404868344547388:1761863290393809500"
  }
},
{
  "cid": 5,
  "aoid": "404868344529070:1761863290393805100",
  "component_type": "Internal_Component",
  "internal_component_type": "Polygon_Collider",
  "data": {
    "make_navmesh_loop": true,
    "flip_navmesh_loop": true,
    "points": [
      {
        "X": -0.1877212524414062,
        "Y": -0.2063050270080566
      },
      {
        "X": 0.0189009904861450,
        "Y": -0.2597980499267578
      },
      {
        "X": 0.2158927917480469,
        "Y": -0.1123766899108887
      },
      {
        "X": 0.0703394412994385,
        "Y": 0.1123763322830200
      },
      {
        "X": -0.1783308982849121,
        "Y": 0.0560193061828613
      }
    ]
  }
}
