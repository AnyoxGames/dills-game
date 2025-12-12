13
3921305141249
404952249567180 1761863309943766500
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": -7.6690092086791992,
    "Y": -8.8290147781372070
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "404950318673357:1761863309493866400",
  "next_sibling": "404954323786862:1761863310427062000",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "404952249833436:1761863309943827900",
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
  "aoid": "404952249950654:1761863309943855200",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "404952249833436:1761863309943827900",
    "DefaultRenderer": "404952250000319:1761863309943866800",
    "DepletedRenderer": "404952249985441:1761863309943863300"
  }
},
{
  "cid": 5,
  "aoid": "404952249964070:1761863309943858300",
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
